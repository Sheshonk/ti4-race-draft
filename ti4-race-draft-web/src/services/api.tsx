//const hostname = process.env.
const hostname = "https://localhost:7179/api";

export const CreateGame = (
    names: string[]
) => {
    return fetch(
        `${hostname}/Game`,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(names)
        }
    ).then((response) => response.json())
    .then((data) => {
        return data;
    })
    .catch((error) => {
        console.error(error);
        throw error;
    })
}

export const CreatePlayer = (
    gameId: number,
    playerId: number
) => {
    let body = { 
        "gameId": gameId,
        "playerId": playerId
    };

    return fetch(
        `${hostname}/Player`,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(body)
        }
    ).then((response) => response.json())
    .then((data) => {
        return data;
    })
    .catch((error) => {
        console.error(error);
        throw error;
    })
}

export const DeletePlayer = (
    adminAuthToken: string,
    gameId: number,
    playerId: number
) => {
    let body = { 
        "adminAuthToken": adminAuthToken,
        "gameId": gameId,
        "playerId": playerId
    };

    return fetch(
        `${hostname}/Player`,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'DELETE',
            body: JSON.stringify(body)
        }
    ).then((response) => response.json())
    .then((data) => {
        return data;
    })
    .catch((error) => {
        console.error(error);
        throw error;
    })
}

export const GetGame = (
    publicId: string,
    authToken: string|null
) => {
    let url = `${hostname}/Game?publicId=${encodeURIComponent(publicId)}`;
    if (authToken) url += `&authToken=${encodeURIComponent(authToken)}`;

    return fetch(
        url,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'GET'
        }
    ).then((response) => response.json())
    .then((data) => {
        return data;
    })
    .catch((error) => {
        console.error(error);
        throw error;
    })
}