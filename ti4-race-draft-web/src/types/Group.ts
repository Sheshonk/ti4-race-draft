import { Race } from './Race';

export type Group = {
    id: number,
    name: string,
    winner: boolean,
    races: Race[]
};