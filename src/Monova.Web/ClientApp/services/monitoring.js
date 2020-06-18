import { http } from '@/utils/http'
const MonitoringService = {
  async list () {
    var result = await http.get('/api/v1/monitoring')
    console.log(result)
    if (result.status === 200) { return result.data } else {
      console.log(result.error)
    }
  },
  async save (value) {
    var result = await http.post('/api/v1/monitoring', value)

    if (result.status === 200) { return result.data } else {
      console.log(result.error)
      throw result.error
    }
  }
}
export default MonitoringService // dışarıdan kullabilmek için export ediyoruz
