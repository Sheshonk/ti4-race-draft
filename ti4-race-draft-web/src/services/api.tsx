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