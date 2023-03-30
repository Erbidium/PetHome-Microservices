import axios from 'axios';
export const url = 'http://172.30.135.173' // 'http://172.24.79.8'

const $api = axios.create({
    withCredentials: true,
    baseURL: url,
})

export default $api;