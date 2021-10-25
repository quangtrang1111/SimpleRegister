// const BASE_ENDPOINT = 'https://localhost:5001'
const BASE_ENDPOINT = 'https://simpleregister.azurewebsites.net'

const api = {
    get: async (url) => {
        const response = await fetch(`${BASE_ENDPOINT}/${url}`, {
            method: 'GET',
            headers: {
                'accept': 'application/json',
                'content-type': 'application/json'
            },
        });

        if (response.status < 200 || response.status >= 300) {
            throw new Error(response.text());
        }

        try {
            return await response.json();
        } catch (error) {}
    },    
    post: async (url, data) => {
        const response = await fetch(`${BASE_ENDPOINT}/${url}`, {
            method: 'POST',
            headers: {
                'accept': 'application/json',
                'content-type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.status < 200 || response.status >= 300) {
            throw new Error(response.text());
        }

        try {
            return await response.json();
        } catch (error) {}
    }
}

export default api;