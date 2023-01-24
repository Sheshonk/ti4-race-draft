//const hostname = process.env.
//const hostname = "https://localhost:7179/api";
const hostname = "http://www.sheshonk.com:9012/api";

export const CreateDraft = (
    draftId: number,
    gameId: number,
    groupId: number,
    playerId: number,
    authToken: string
) => {
    let body = {
        "draftId": draftId,
        "gameId": gameId,
        "groupId": groupId,
        "playerId": playerId,
        "authToken": authToken
    };

    return fetch(
        `${hostname}/Draft`,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(body)
        }
    ).then(() => {
        return null;
    })
    .catch((error) => {
        console.error(error);
        throw error;
    })
}

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
    ).then((response) => { return null})
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