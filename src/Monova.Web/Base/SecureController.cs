using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace Monova.Web
{
    // Bu controller sadece authenticate olan kullanıcılar için 
    // Bir controller Secure controllerdan türüyorsa, ne olursa olsun o kullanıcıya authentice olma zorunluluğu getir
    [Authorize]
    public class SecureController : Controller
    {

    }

}