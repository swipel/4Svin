import { Observable } from "rxjs";
import { Statistic } from "./Statistic"

export class Box {
    Amount: number;
    TypeId: number;
    TypeName: string;
    Statistics: Statistic[];

}