import { http } from '@/utils/http'
const MonitoringService = {
  async list () {
    var result = await http.get('/api/v1/monitoring')
    if (result.status === 200) { return result.data } else {
    }
  },
  async getById (id) {
    if (id) {
      var result = await http.get(`/api/v1/monitoring/${id}`)
      if (result.status === 200) {
        return result.data
      }
    }
  },
  async save (value) {
    var result = await http.post('/api/v1/monitoring', value)

    if (result.status === 200) {
      return result.data
    } else {
      throw result.error
    }
  }
}
export default MonitoringService // dışarıdan kullabilmek için export ediyoruz
