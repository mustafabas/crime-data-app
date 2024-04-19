
export type SelectItem={
    id:number;
    text:string;
}

export type FilterResponse = {
    cities:SelectItem[];
    Sources:SelectItem[];
}
export type FilterRequest = {
    cityId:number;
    daysBefore:number;
  }