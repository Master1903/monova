using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace Monova.Web
{
    [Authorize]
    public class SecureDbController : DbController
    {

    }

}