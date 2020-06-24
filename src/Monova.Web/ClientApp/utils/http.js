
import Vue from 'vue'
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
    let myData = response.data

    if (myData) {
      if (myData.success && myData.message) {
        SendNotify('Success!', myData.message, StatusCode.success)
      }
    }

    return response
  },
  function (error) { // bu parametre ise hata oluştuğundaki aksiyonları yöneten function
    const errorCode = error.response.status
    let myData = error
    if (!myData.success && myData.message) {
      SendNotify('Error', myData.message, StatusCode.error.toString(), 10000)
    }

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

function SendNotify (title, text, type, duration) {
  return Vue.notify({
    title: title,
    text: text,
    type: type,
    duration: duration
  })
}
const StatusCode = {
  error: 'error',
  success: 'success',
  info: 'info',
  warn: 'warn'
}
