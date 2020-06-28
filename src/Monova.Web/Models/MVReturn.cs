using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monova.Web
{
    public class MVReturn
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // Dönüş değelerinde null varsa gözükmesin
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public string InternalMessage { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public int Code { get; set; } // kendi hata kodlarımız olarak kullanabiliriz
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
        public bool Success { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<MVReturnError> Errors { get; set; } // detay mesajları veya birden fazla hata mesajı varsa kullanılacak


    }

    public class MVReturnError
    {

        public string Message { get; set; } // kullanıcı mesajı
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InternalMessage { get; set; } // api yi kullanan kullanıcı mesajı
        public string Name { get; set; }
    }

}
