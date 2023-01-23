import { ChangeEvent, useEffect, useState } from 'react';
import { CreateDraft, CreatePlayer, DeletePlayer, GetGame } from '../services/api';
import { Game } from '../types/Game';
import { Group } from '../types/Group';
import { Player } from '../types/Player';
import { Race } from '../types/Race';
import { renderMatches, useLocation } from 'react-router-dom';

export const Draft = () => {
    const location = useLocation();
    const [game, setGame] = useState<Game | null>(null);
    const [publicId, setPublicId] = useState("");
    const [authToken, setAuthToken] = useState<string | null>(null);
    const [draftRace, setDraftRace] = useState("");
    const [draftGroup, setDraftGroup] = useState("");

    useEffect(() => {
        //TODO: why does this fire twice?
        setPublicId(location.pathname.substring('/draft/'.length));
    }, []);

    useEffect(() => {
        //TODO: delay on set state is a pain in the ass
        let authToken = localStorage.getItem(publicId);
        if (authToken)
            setAuthToken(authToken);
        else
            LoadGame();
    }, [publicId])

    useEffect(() => {
        LoadGame();
    }, [authToken]);

    const ClaimPlayer = (gameId:number, playerId: number) => {
        CreatePlayer(gameId, playerId).then((data: string) => {
            localStorage.setItem(publicId, data);
            setAuthToken(data);
        });
    }

    const Draft = () => {
        CreateDraft(+draftRace, (game as Game).id, +draftGroup, (game as Game).authPlayerId, (authToken as string)).then(() => {
            LoadGame();
        });
    }

    const HandleDraftRaceChange = (e: ChangeEvent) => {
        setDraftRace((e.target as HTMLInputElement).value);
    }

    const HandleDraftGroupChange = (e: ChangeEvent) => {
        setDraftGroup((e.target as HTMLInputElement).value.toString());
    }

    const LoadGame = () => {
        //TODO: remove guard
        if (publicId) {
            GetGame(publicId, authToken).then((data: Game) => {
                setGame(data);
                for (let i = 0; i < data.groups.length; i++) {
                    if (data.groups[i].races.length < 6) {
                        setDraftGroup(data.groups[i].id.toString());
                        break;
                    }
                }
                setDraftRace(data.hand[0].draftId.toString());
            });
        }
    }

    const UnclaimPlayer = ( playerId: number ) => {
        DeletePlayer(authToken as string, (game as Game).id, playerId).then(() => {
            LoadGame();
        });
    }

    if (game) {
        return (
            <>
                <h1>TI4 Race Draft</h1>
                { (game.complete) ? (
                    <>
                        <p>Group "{ game.groups.filter(group => group.winner === true)[0].name }" is the winner.</p>
                    </>
                ) : (
                    <>
                        <p>It's <b>{game.currentPlayer.name}'s</b> turn to draft</p>
                        <hr />
                    </>
                )}
                <h3>Players</h3>
                <ol>
                    {game.players.map((player, i) => (
                        <li key={i}>
                            <>
                                { (player.id == game.authPlayerId) ? <b><span>{player.name} </span></b> : <span>{player.name} </span> }
                            </>
                            <>
                                { (player.claimable && !game.authPlayerId) ? <button onClick={() => ClaimPlayer(game.id, player.id)}>Claim</button> : null }
                            </>
                            <>
                                { (!player.claimable && game.adminId === game.authPlayerId) ? <button onClick={() => UnclaimPlayer(player.id)}> Reset Claim</button> : null }
                            </>
                        </li>
                    ))}
                </ol>
                <hr />
                <>
                    { (!game.complete && game.currentPlayer.id === game.authPlayerId) ? (
                        <>
                            <h3>Draft</h3>
                            <h5>Race</h5>
                            <>
                                {game.hand.map((race, i) => (
                                    <div key={i}>
                                        <label>
                                            <input type="radio" name="draft_race" value={race.draftId.toString()} checked={draftRace == race.draftId.toString()} onChange={ HandleDraftRaceChange } />
                                            {race.name}
                                        </label>
                                        <br />
                                    </div>
                                ))}
                            </>
                            <h5>Group</h5>
                            <>
                                {game.groups.map((group, i) => (
                                    <div key={i}>
                                        { (group.races.length < 6) ? (
                                            <>
                                                <label>
                                                    <input type="radio" name="draft_group" value={group.id.toString()} checked={draftGroup == group.id.toString()} onChange={ HandleDraftGroupChange } />
                                                    Group {i+1} "{group.name}"
                                                </label>
                                                <br />
                                            </>
                                        ) : null }
                                    </div>
                                ))}
                            </>
                            <br />
                            <button onClick={Draft}>Draft</button>
                            <hr />
                        </>
                    ) : null}
                </>                
                <>
                    { (game.hand && game.hand.length > 0) ? (
                        <>
                            <h3>Hand</h3>
                            <ol>
                                {game.hand.map((race, i) => (
                                    <li key={i}>
                                        <a href={race.wikiUrl} target="_blank">{race.name}</a>
                                    </li>
                                ))}
                            </ol>
                            <hr />
                        </>
                    ) : null}
                </>
                <h3>Groups</h3>
                <h5>Super Faction (Faction revelead at end of draft and part of every group)</h5>
                <ol>
                    <>
                        { (game.superFaction) 
                            ? <li><a href={game.superFaction.wikiUrl} target="_blank">{game.superFaction.name}</a></li>
                            : <li>?</li>
                        }
                    </>
                </ol>
                <>
                    {game.groups.map((group, i) => (
                        <div key={i}>
                            <h5>Group {i+1} "{group.name}"</h5>
                            <ol>
                                <>
                                    {[0,1,2,3,4,5].map((val, k) => (
                                        <li key={k}>
                                            <>
                                                { group.races[k] ? <a href={group.races[k].wikiUrl} target="_blank">{group.races[k].name}</a> : <span>?</span> }
                                            </>
                                        </li>
                                    ))}
                                </>
                            </ol>
                        </div>
                    ))}
                </>
            </>
        );
    } else {
        return (
            <h3>Loading</h3>
        )
    }
};

export default Draft;