import axios from 'axios';
export const url = 'http://172.24.79.8' // 'http://172.24.79.8'

const $api = axios.create({
    withCredentials: true,
    baseURL: url,
})

export default $api;