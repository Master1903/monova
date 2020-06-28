using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Monova.Entity;
using System;
using System.Security.Claims;

namespace Monova.Web
{
    /// Bu Controller çeşidi, sadece api olarak kullanılacak. Yani vue tarafında sayfalarımızı bu controllerdan türeyen classların içindeki ActionResult metodları kullanacak.
    [Route("api/v1/[controller]")]
    public class ApiController : SecureDbController
    {
        private readonly UserManager<MVDUser> _userManager;
        public UserManager<MVDUser> UserManager => _userManager ?? (UserManager<MVDUser>)HttpContext?.RequestServices.GetService(typeof(UserManager<MVDUser>));

        public Guid _userId => Guid.Parse(UserManager.GetUserId(User));




        [NonAction]
        public IActionResult Success(string message = default(string), object data = default(object), int code = 200)
        {
            return Ok(
                new MVReturn
                {
                    Success = true,
                    Message = message,
                    Data = data,
                    Code = code
                }
            );
        }

        [NonAction]
        public IActionResult Error(string message = default(string), string internalMessage = default(string), string data = default(string), int code = 500)
        {
            var rv = new MVReturn
            {
                Success = false,
                Message = message,
                InternalMessage = internalMessage,
                Data = data,
                Code = code
            };

            if (rv.Code == 500)
                return StatusCode(500, rv);

            else if (rv.Code == 401)
                return Unauthorized();

            else if (rv.Code == 403)
                return Forbid();

            else if (rv.Code == 404)
                return NotFound(rv);

            return BadRequest(rv);
        }

    }

}