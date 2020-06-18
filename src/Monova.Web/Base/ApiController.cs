using Microsoft.AspNetCore.Mvc;
using System;
namespace Monova.Web
{
    /// Bu Controller çeşidi, sadece api olarak kullanılacak. Yani vue tarafında sayfalarımızı bu controllerdan türeyen classların içindeki ActionResult metodları kullanacak.
    [Route("api/v1/[controller]")]
    public class ApiController : SecureDbController
    {

    }

}