import axios from 'axios';
export const url = 'http://localhost:3030' // 'http://192.168.51.114'

const $api = axios.create({
    withCredentials: true,
    baseURL: url,
})

export default $api;