import $api from "./index"

export default class AdvertService {
    static async getAllAdverts() {
        const response = await $api.get('/api/adverts');
        return response
    }
    static async getCertainAdvert(id) {
        const response = await $api.get('/api/adverts/' + id)
        return response.data
    }
    static async createAdvert(advertData) {
        const response = await $api.post('/api/adverts/', advertData)
        return response.data
    }
    static async markAsFinished(id) {
        const response = await $api.put('/api/adverts/finish/' + id)
        return response.data
    }
    static async deleteAdvert(id) {
        const response = await $api.delete('/api/adverts/' + id)
        return response.data
    }
    static async redoUserAdvert(redoData, id) {
        const response = await $api.put('/api/myadverts/' + id, redoData)
        return response.data
    }
}