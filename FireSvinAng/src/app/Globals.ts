import { Injectable } from '@angular/core';

//This is an injectable singleton, we use this so every component is always in agreement on what the currentfarm is. 

@Injectable()
export class Globals {
    currentFarm: number = 1;
}