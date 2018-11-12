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
    public class BarnsController : ControllerBase
    {
        private readonly ApiManager _apiManager = new ApiManager();

        [HttpGet("{farmId}")]
        public ActionResult Get(int farmId)
        {
            var barns = _apiManager.GetAllBarnsByFarmId(farmId).ToList();
            if (barns.Count > 0)
            {
                return Ok(barns);
            }
            else
            {
                return NotFound("Fail");
            }
        }
    }
}