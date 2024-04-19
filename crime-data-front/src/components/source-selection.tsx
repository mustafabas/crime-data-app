
import React, { useEffect, useState } from "react";
import Selection  from "./selection";
import { FilterResponse, SelectItem } from "../constant/types";
import { GET_FILTER_ITEMS } from "../constant/constant";


const CitySelection = () => {
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
                    throw new Error('Failed to fetch data');
                }
                const data : FilterResponse =  await response.json();

                setCities(data.cities);
            } catch (error) {
                setIsError(true);
            }
        };

        fetchData();
    }, []);

    const onChange=(val:string)=>{
        setCityId(val);
    }       

    return (
        <Selection data={cities} label="Select City" onChange={onChange} value="cityId" key="cityId"></Selection>
    );
}

export default CitySelection;