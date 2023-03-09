import $api from "./index"

export default class UserService {
    static async getAllUsers() {
        return await $api.get('/api/users')
    }
    static async getUser(id) {
        const { data } = await $api.get('/api/users/' + id)
        return data
    }
    static async createUser(userData) {
        const { data } = await $api.post('/api/users/', userData)
        return data
    }

    static async deleteUser(id) {
        const { data } = await $api.delete('/api/users/' + id)
        return data
    }

    static async updateUser(updatedUserData, id) {
        const response = await $api.put('/api/users/' + id, updatedUserData)
        return response.data
    }
}
