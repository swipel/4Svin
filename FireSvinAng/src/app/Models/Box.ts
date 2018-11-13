import { Observable } from "rxjs";
import { Statistic } from "./Statistic"

export class Box {
    
    boxNumber: number;
    barnNumber: number;
    farmId: number;
    boxType: string;
    boxTypeId: number;
    animalAmount: number;

    constructor(data: Box|Object) {
        Object.assign(this, data);
        
    }



}