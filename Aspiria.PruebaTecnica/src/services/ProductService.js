import axios from 'axios'
const ProductService = {
    urlApi: '/api/Products',
    async fetch() {
        return axios.get(this.urlApi)
    },
    async find(id) {
        return axios.get(`${this.urlApi}/${id}`)
    },
    async save(data) {
        return axios.post(this.urlApi, data)
    },
    async update(id, data) {
        return axios.patch(`${this.urlApi}/${id}`,data)
    },
    async remove(id) {
        return axios.delete(`${this.urlApi}/${id}`)
    }
}

export default ProductService