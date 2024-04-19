
import React, { useEffect, useState } from "react";
import Selection from "./selection";
import { FilterRequest, FilterResponse, SelectItem } from "../constant/types";
import { GET_FILTER_ITEMS } from "../constant/constant";
import { Snackbar } from "@mui/material";

interface CitySelectionProps {
    onChange?:(cityId:number)=>void
}

const CitySelection = (props:CitySelectionProps) => {
    const{onChange} =props;

    const [cityId, setCityId] = React.useState('');
    const [isError, setIsError] = React.useState(false);
    const [cities, setCities] = useState<SelectItem[]>([]);


    const handleClose = (event: React.SyntheticEvent | Event, reason?: string) => {
        if (reason === 'clickaway') {
            return;
        }
        setIsError(false);
    };
    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(GET_FILTER_ITEMS);
                if (!response.ok) {
                    setIsError(true);
                }
                const data: FilterResponse = await response.json();

                setCities(data.cities);
            } catch (error) {
                setIsError(true);
            }
        };
        fetchData();
    }, []);

    const onChangeSelection = (val: string) => {
        setCityId(val);

    }


    useEffect(()=>{
        if(onChange)
        onChange(parseInt(cityId));
    },[cityId])

    return (
        <>
            <Selection data={cities} label="Select City" onChange={onChangeSelection} value="" key="cityId"></Selection>
            {isError && <Snackbar
                open={isError}
                autoHideDuration={6000}
                onClose={handleClose}
                message="Error occured while fetcing filter items"
            />
            }
        </>
    );
}

export default CitySelection;