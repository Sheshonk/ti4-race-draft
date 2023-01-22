import { useState } from 'react';
import { CreateGame } from '../services/api';
import { Dict } from '../types/Dict';
import { useNavigate } from 'react-router-dom';

export const Setup = () => {
    const navigate = useNavigate();
    const [player1, setPlayer1] = useState("");
    const [player2, setPlayer2] = useState("");
    const [player3, setPlayer3] = useState("");
    const [player4, setPlayer4] = useState("");
    const [player5, setPlayer5] = useState("");
    const [player6, setPlayer6] = useState("");

    const Submit = (e: React.SyntheticEvent) => {
        e.preventDefault();

        let players = [player1, player2, player3, player4, player5, player6];
        CreateGame(players).then((data: Dict) => {
            navigate(`/draft/${data.id}`);
        });
    }

    return (
        <div className="flex items-center justify-center h-screen bg-slate-100">
            <div className="block p-6 rounded-lg shadow-lg bg-white max-w-sm">
                <form onSubmit={Submit}>
                    <div className="form-group mb-6">
                        <label 
                            htmlFor="player1" 
                            className="form-label inline-block mb-2 text-gray-700"
                        >
                            Player 1
                        </label>
                        <input 
                            type="text" 
                            className="form-control block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none" 
                            id="player1"
                            aria-describedby="emailHelp" 
                            placeholder="Name"
                            value={player1}
                            onInput={e => setPlayer1((e.target as HTMLInputElement).value)}
                        />
                    </div>
                    <div className="form-group mb-6">
                        <label 
                            htmlFor="player2" 
                            className="form-label inline-block mb-2 text-gray-700"
                        >
                            Player 2
                        </label>
                        <input 
                            type="text" 
                            className="form-control block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none" 
                            id="player2"
                            aria-describedby="emailHelp" 
                            placeholder="Name"
                            value={player2}
                            onInput={e => setPlayer2((e.target as HTMLInputElement).value)}
                        />
                    </div>
                    <div className="form-group mb-6">
                        <label 
                            htmlFor="player3" 
                            className="form-label inline-block mb-2 text-gray-700"
                        >
                            Player 3
                        </label>
                        <input 
                            type="text" 
                            className="form-control block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none" 
                            id="player3"
                            aria-describedby="emailHelp" 
                            placeholder="Name"
                            value={player3}
                            onInput={e => setPlayer3((e.target as HTMLInputElement).value)}
                        />
                    </div>
                    <div className="form-group mb-6">
                        <label 
                            htmlFor="player4" 
                            className="form-label inline-block mb-2 text-gray-700"
                        >
                            Player 4
                        </label>
                        <input 
                            type="text" 
                            className="form-control block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none" 
                            id="player4"
                            aria-describedby="emailHelp" 
                            placeholder="Name"
                            value={player4}
                            onInput={e => setPlayer4((e.target as HTMLInputElement).value)}
                        />
                    </div>
                    <div className="form-group mb-6">
                        <label 
                            htmlFor="player5" 
                            className="form-label inline-block mb-2 text-gray-700"
                        >
                            Player 5
                        </label>
                        <input 
                            type="text" 
                            className="form-control block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none" 
                            id="player5"
                            aria-describedby="emailHelp" 
                            placeholder="Name"
                            value={player5}
                            onInput={e => setPlayer5((e.target as HTMLInputElement).value)}
                        />
                    </div>
                    <div className="form-group mb-6">
                        <label 
                            htmlFor="player6" 
                            className="form-label inline-block mb-2 text-gray-700"
                        >
                            Player 6
                        </label>
                        <input 
                            type="text" 
                            className="form-control block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none" 
                            id="player6"
                            aria-describedby="emailHelp" 
                            placeholder="Name"
                            value={player6}
                            onInput={e => setPlayer6((e.target as HTMLInputElement).value)}
                        />
                    </div>
                    <button 
                        type="submit" 
                        className="px-6 py-2.5 bg-blue-600 text-white font-medium text-xs leading-tight uppercase rounded shadow-md hover:bg-blue-700 hover:shadow-lg focus:bg-blue-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out"
                    >
                        Submit
                    </button>
                </form>
            </div>
        </div>
    );
}

export default Setup;