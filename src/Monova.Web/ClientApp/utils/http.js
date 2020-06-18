import axios from 'axios'
import router from '@/router'

export const http = axios.create({
  headers: {
    'Content-Type': 'application/json',
    'X-Requested-With': 'XMLHttpRequest',
    'X-Application-Name': 'vue'
  }
})

// sitede dolaşırken sistem authentication yani session düşerse kullanıcıyı login sayfasına yönlendir
http.interceptors.response.use( // 1.parametre response geldikten sonraki kısmı yönetmek için
  function (response) {
    return response
  },
  function (error) { // bu parametre ise hata oluştuğundaki aksiyonları yöneten function
    const errorCode = error.response.status
    if (errorCode === 401) {
      window.location.href = `/Identity/Account/Login?ReturnUrl=${encodeURIComponent(window.location.pathname)}` // en son hangi sayfada kaldıysa login olduktan sonra o sayfaya yönelndir
      return new Promise(() => { })
    }
    if (errorCode === 403) {
      router.push({
        name: 'forbidden'
      })
      return new Promise(() => { })
    }

    return Promise.reject(error)
  }
)
