using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmAPI.Manager;
using FarmAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace FarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly ApiManager _apiManager = new ApiManager();
        
        [HttpGet]
        public ActionResult Get()
        {
            //TODO RETURN USER
            return Ok();

        }
    }
}