import axios from 'axios';

const $api = axios.create({
    withCredentials: true,
    baseURL: '/',
})

export default $api;
