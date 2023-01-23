import { Player } from './Player';

export type Game = {
    id: number,
    authPlayerId: number,
    currentPlayer: Player,
    superFaction: null,
    complete: boolean,
    players: Player[],
    hand: null,
    groups: null
};