/*function status(response) {
    if (response.status >= 200 && response.status < 300) {
        return Promise.resolve(response)
    } else {
        return Promise.reject(new Error(response.statusText))
    }
}

let defaultOptions = {
    url: '',
    method: 'GET',
    mode: 'cors',
    credentials: 'include',
    cache: 'default',
    headers: {
        'Content-Type': 'jsonp',
        'Access-Control-Allow-Origin': '*'
    },
    body: null,
};*/
async function fetch_adverts() {
    return await fetch('https://localhost:44396/api/adverts/4005/', {
        mode: 'no-cors',
        method: 'get', credentials: 'same-origin', headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': 'null'
        },
        dataType: 'json',
    })
        .then(res => res.json())
        .catch(Error);
}