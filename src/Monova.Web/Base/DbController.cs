using Microsoft.AspNetCore.Mvc;
using Monova.Entity;
using System;
namespace Monova.Web
{
    public class DbController : Controller
    {
        private MVDContext _db;

        //Access DbContext
        public MVDContext db => _db ?? (MVDContext)HttpContext?.RequestServices.GetService(typeof(MVDContext));



    }

}