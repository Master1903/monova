import { http } from '@/utils/http'
const MonitoringService = {
  async list () {
    var result = await http.get('/api/v1/monitoring')
    if (result.status === 200) return result.data
  },
  async getById (id) {
    if (!id) return
    var result = await http.get(`/api/v1/monitoring/${id}`)
    if (result.status !== 200) return

    return result.data
  },
  async save (value) {
    var result = await http.post('/api/v1/monitoring', value)

    if (result.status !== 200) throw result.error

    return result.data
  },
  async update (value) {
    var result = await http.put('/api/v1/monitoring', value)

    if (result.status !== 200) throw result.error

    return result.data
  }
}
export default MonitoringService // dışarıdan kullabilmek için export ediyoruz
