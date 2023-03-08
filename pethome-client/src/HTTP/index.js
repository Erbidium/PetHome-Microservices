import axios from 'axios';
export const url = 'http://192.168.51.114' // https://localhost:7124, empty if docker compose

const $api = axios.create({
    withCredentials: true,
    baseURL: url
})

export default $api;