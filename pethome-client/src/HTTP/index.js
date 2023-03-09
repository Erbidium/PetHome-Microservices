import axios from 'axios';
export const url = 'https://localhost:7297' // 'http://192.168.51.114'

const $api = axios.create({
    withCredentials: true,
    baseURL: url,
})

export default $api;