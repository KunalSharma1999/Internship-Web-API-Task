import { FilterOptions } from "../shared/enums/filter-options";

export class Filter{
    public value: string;
    public filterType: FilterOptions

    constructor(args:any){
        args = !!args ? args : {};
        this.value = args.value ? args.value : '';
        this.filterType = args.filterType ? args.filterType : '';
    }
}