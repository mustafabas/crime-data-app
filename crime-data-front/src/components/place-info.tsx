import React, { useState } from "react";
import { Marker, InfoWindow } from "@react-google-maps/api";

type locationobject={
    lat:number;
    lng:number;
}
type place ={
    info:string;
    location:locationobject
}
export default function PlaceInfo() {
  const places : place[] = [
    {
      info: "YSKe-com (Main Office)",
      location: { lat: 35.64860429083234, lng: 138.57693376912908 }
    },
    {
      info: "YSKe-com (Do-Kasuga)",
      location: { lat: 35.658687875856664, lng: 138.56954332425778 }
    },
    {
      info: "YSKe-com (Do-ChuoV)",
      location: { lat: 35.66014231235642, lng: 138.57494260883726 }
    }
  ];

  const [selected, setSelected] = useState<place>();

  return (
    <>
      {places.map((marker) => (
        <Marker
          key={`${marker.location.lat * marker.location.lng}`}
          position={{
            lat: marker.location.lat,
            lng: marker.location.lng
          }}
          onMouseOver={() => {
            setSelected(marker);
          }}
        />
      ))}

      {selected ? (
        // MarkerにマウスオーバーされたときにInfoWindowが表示されます。
        <InfoWindow
          position={{
            lat: selected.location.lat,
            lng: selected.location.lng
          }}
          onCloseClick={() => {
            setSelected(undefined);
          }}
        >
          <div>{selected.info}</div>
        </InfoWindow>
      ) : null}
    </>
  );
}
