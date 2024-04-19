import React, { useEffect, useState } from "react";
import CitySelection from "./city-selection";
import { Grid } from "@mui/material";
import DaysBeforeSelection from "./day-selection";
import { FilterRequest } from "../constant/types";

export interface FilterProps{
    onChange:(filter:FilterRequest)=>void
}

const Filter = (props:FilterProps) => {
    const {onChange} = props;
    const [cityId, setCityId] = useState(0);
    const [daysBefore, setDaysBefore]= useState(0);
    
    const onChangeCity =(val:number)=>{
        setCityId(val);
    }
    const onChangeDaysBefore =(val:number)=>{
        setDaysBefore(val);
    }

    useEffect(()=>{
        var filterRequest:FilterRequest={cityId:cityId, daysBefore:daysBefore};
        onChange(filterRequest);

    },[cityId,daysBefore])
    return (
        <Grid container spacing={2}>
              <Grid item xs={2}><CitySelection onChange={onChangeCity}></CitySelection></Grid>
              <Grid item xs={2}><DaysBeforeSelection onChange={onChangeDaysBefore}></DaysBeforeSelection></Grid>

        </Grid>

    );
}

export default Filter;