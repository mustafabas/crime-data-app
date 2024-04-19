import { FormControl, InputLabel, MenuItem, Select, SelectChangeEvent } from "@mui/material"
import { useState } from "react";
import { SelectItem } from "../constant/types";


interface SelectionProps{
    data:SelectItem[],
    onChange:(val:string) => void,
    value:string,
    label:string
}


const Selection = (props : SelectionProps) =>{
    const {data, value, onChange, label} = props;
    const [selectedVal, setSelectedVal]= useState(value);
    
    const handleChange = (event: SelectChangeEvent) => {
        setSelectedVal(event.target.value as string);
        onChange(event.target.value as string);
    };
    return (
        <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">{label}</InputLabel>
        <Select
            labelId="demo-simple-select-label"
            id="city-selection"
            value={selectedVal}
            label={label}
            onChange={handleChange}
        >
            {data.length > 0 && data.map(d => <MenuItem key={d.id} value={d.id}>{d.text}</MenuItem>)}
        </Select>

    </FormControl>
    )
}

export default Selection;