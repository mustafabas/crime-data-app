
import React, { useEffect, useState } from "react";
import Selection from "./selection";
import { SelectItem } from "../constant/types";


interface DaySelectionProps {
    onChange?: (val: number) => void,
}

const DaysBeforeSelection = (props: DaySelectionProps) => {
    const { onChange } = props;
    const [dayBefore, setDayBefore] = React.useState(7);
    const [numbers, setNumbers] = React.useState<SelectItem[]>([]);


    useEffect(() => {
        const initiateDays = () => {
            var numberArray: SelectItem[] = [];
            numberArray.push({ id: 7, text: `7 days before` });
            numberArray.push({ id: 14, text: `14 days before` });
            numberArray.push({ id: 28, text: `28 days before` });
            setNumbers(numberArray);
        };
        initiateDays();
    }, []);

    const onChangeSelection = (val: string) => {
        setDayBefore(parseInt(val));
    }

    useEffect(() => {
        if (onChange)
            onChange(dayBefore);
    }, [dayBefore])

    return (
        <>
            <Selection data={numbers} label="7 days before" onChange={onChangeSelection} value="7" key="daysBefore"></Selection>
        </>
    );
}

export default DaysBeforeSelection;