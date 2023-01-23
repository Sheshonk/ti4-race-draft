import { useEffect, useState } from 'react';
import { CreatePlayer, DeletePlayer, GetGame } from '../services/api';
import { Game } from '../types/Game';
import { Player } from '../types/Player';
import { useLocation } from 'react-router-dom';

export const Draft = () => {
    const location = useLocation();
    const [game, setGame] = useState<Game | null>(null);
    const [publicId, setPublicId] = useState("");
    const [authToken, setAuthToken] = useState<string | null>(null);

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

    const LoadGame = () => {
        //TODO: remove guard
        if (publicId) {
            GetGame(publicId, authToken).then((data: Game) => {
                setGame(data);
            });
        }
    }

    if (game) {
        return (
            <>
                <h1>TI4 Race Draft</h1>
                <p>It's {game.currentPlayer.name}'s turn to draft</p>
                <hr />
                <h3>Players</h3>
                <ol>
                    {game.players.map((player, i) => (
                        <li key={i}>
                            <span>{player.name} </span>
                            <>
                                { (player.claimable) ? <button onClick={() => ClaimPlayer(game.id, player.id)}>Claim</button> : null }
                            </>
                            <>
                                { (!player.claimable && game.authPlayerId === game.currentPlayer.id) ? <a href="#">Reset Claim</a> : null }
                            </>
                        </li>
                    ))}
                </ol>
                <hr />
            </>
        );
    } else {
        return (
            <h3>Loading</h3>
        )
    }
};

export default Draft;