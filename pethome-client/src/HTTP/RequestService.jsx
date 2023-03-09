import $api from "./index"

export default class RequestService {
    static async getAllRequests() {
        const response = await $api.get('/api/requests');
        return response
    }
    static async getCertainRequest(id) {
        const response = await $api.get('/api/requests/' + id)
        return response.data
    }
    static async createRequest(advertId) {
        const response = await $api.post('/api/requests/', advertId)
        return response.data
    }
    static async applyRequest(id) {
        const response = await $api.put('/api/requests/apply/' + id)
        return response.data
    }
    static async confirmRequest(id) {
        const response = await $api.put('/api/requests/confirm/' + id)
        return response.data
    }
    static async rejectRequest(id) {
        const response = await $api.put('/api/requests/reject/' + id)
        return response.data
    }
    static async deleteRequest(id) {
        const response = await $api.delete('/api/requests/' + id)
        return response.data
    }
}