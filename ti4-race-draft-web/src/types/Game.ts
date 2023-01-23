import { Group } from './Group';
import { Player } from './Player';
import { Race } from './Race';

export type Game = {
    id: number,
    authPlayerId: number,
    adminId: number,
    currentPlayer: Player,
    superFaction: Race,
    complete: boolean,
    players: Player[],
    hand: Race[],
    groups: Group[]
};