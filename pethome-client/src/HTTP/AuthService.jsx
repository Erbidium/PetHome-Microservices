import $api from "./index";

export default class AuthService {
    static async signUp(record) {
        const response = await $api.post('/auth/signup', record)
        return response
    }
    static async signIn(record) {
        const response = await $api.post('/auth/signin', record)
        return response
    }
    static async logOut(access) {
        console.log(access)
        const response = await $api.post('/auth/logout', {}, {
            headers: {
                'Authorization': `Bearer ${access}`
            }
        })
        return response
    }
    static async refresh(refresh) {
        const response = await $api.patch('auth/refresh', {
            token: refresh
        })
        return response
    }
}