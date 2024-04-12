'use client'

import GoogleMap, { LatLngBounds, MapContextProps, } from 'google-maps-react-markers'
import { useEffect, useRef, useState } from 'react'
import mapOptions from './map-options.json'
import Marker from './marker'

const coordinates = [
	[
		{
			lat: 45.4046987,
			lng: 12.2472504,
			name: 'Venice',
		},
		{
			lat: 41.9102415,
			lng: 12.3959151,
			name: 'Rome',
		},
		{
			lat: 45.4628328,
			lng: 9.1076927,
			name: 'Milan',
		},
	],
	[
		{
			lat: 40.8518,
			lng: 14.2681,
			name: 'Naples',
		},
		{
			lat: 43.7696,
			lng: 11.2558,
			name: 'Florence',
		},
		{
			lat: 37.5023,
			lng: 15.0873,
			name: 'Catania',
		},
	],
]

export default function Home() {
	const mapRef = useRef<any>(null)
	const [mapReady, setMapReady] = useState<boolean>(false)
	const [mapBounds, setMapBounds] = useState<{ bounds: number[]; zoom: number }>({ bounds: [], zoom: 0 })
	const [usedCoordinates, setUsedCoordinates] = useState<number>(0)
	const [currCoordinates, setCurrCoordinates] = useState(coordinates[usedCoordinates])
	const [highlighted, setHighlighted] = useState<string | null>(null)

	const [dragStart, setDragStart] = useState<{ lat: number; lng: number } | null>(null)
	const [dragEnd, setDragEnd] = useState<{ lat: number; lng: number } | null>(null)
	const [dragging, setDragging] = useState<{ lat: number; lng: number } | null>(null)

	/**
	 * @description This function is called when the map is ready
	 * @param {Object} map - reference to the map instance
	 * @param {Object} maps - reference to the maps library
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	const onGoogleApiLoaded = ({ map, maps }: { map: MapContextProps['map']; maps: MapContextProps['maps'] }) => {
		mapRef.current = map
		setMapReady(true)
	}

	const onMarkerClick = (e: any, { markerId /* , lat, lng */ }: { lat: number; lng: number; markerId: string }) => {
		setHighlighted(markerId)
	}

	const onMapChange = ({ bounds, zoom }: { bounds: LatLngBounds; zoom: number }) => {
		const ne = bounds.getNorthEast()
		const sw = bounds.getSouthWest()
		/**
		 * useSupercluster accepts bounds in the form of [westLng, southLat, eastLng, northLat]
		 * const { clusters, supercluster } = useSupercluster({
		 *	points: points,
		 *	bounds: mapBounds.bounds,
		 *	zoom: mapBounds.zoom,
		 * })
		 */
		setMapBounds({ ...mapBounds, bounds: [sw.lng(), sw.lat(), ne.lng(), ne.lat()], zoom })
		setHighlighted(null)
	}

	const updateCoordinates = () => {
		setUsedCoordinates(!usedCoordinates ? 1 : 0)
		// reset drag
		setDragStart(null)
		setDragEnd(null)
		setDragging(null)
	}

	useEffect(() => {
		setCurrCoordinates(coordinates[usedCoordinates])
	}, [usedCoordinates])

	return (
		<main >
			<div >
				<GoogleMap
					apiKey={process.env.NEXT_PUBLIC_GOOGLE_MAPS_API_KEY ?? ''}
					defaultCenter={{ lat: 45.4046987, lng: 12.2472504 }}
					defaultZoom={5}
					options={mapOptions}
					mapMinHeight="600px"
					onGoogleApiLoaded={onGoogleApiLoaded}
					onChange={onMapChange}
				>
					{currCoordinates.map(({ lat, lng, name }, index) => (
						<Marker
							// eslint-disable-next-line react/no-array-index-key
							key={index}
							lat={lat}
							lng={lng}
							markerId={name}
							onClick={onMarkerClick}
						
							draggable={index === 0}
							onDrag={(e, { latLng }) => setDragging({ lat: latLng.lat, lng: latLng.lng })}
							onDragStart={(e, { latLng }) => setDragStart({ lat: latLng.lat, lng: latLng.lng })}
							onDragEnd={(e, { latLng }) => setDragEnd({ lat: latLng.lat, lng: latLng.lng })}
						/>
					))}
				</GoogleMap>
				{highlighted && (
					<div >
						{highlighted}
						<button type="button" onClick={() => setHighlighted(null)}>
							X
						</button>
					</div>
				)}
			</div>


		</main>
	)
}