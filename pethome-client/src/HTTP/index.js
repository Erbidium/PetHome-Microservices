import axios from 'axios';
export const url = 'http://172.25.157.51' // https://localhost:7124, empty if docker compose

const $api = axios.create({
    withCredentials: true,
    baseURL: url
})

export default $api;