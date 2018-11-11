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
    public class FarmsController : ControllerBase
    {
        private readonly ApiManager _apiManager = new ApiManager();
        
        [HttpGet]
        public ActionResult Get()
        {
            var farms = _apiManager.GetAllFarms().ToList();
            if (farms.Count > 0)
            {
                return Ok(farms);
            }
            else
            {
                return NotFound("Fail");
            }

            //RETURN ALL FARMS
            //TODO only get user farm
        }
        
        [HttpGet("{id}/feed")]
        public ActionResult Get(int id)
        {
            _apiManager.FeedAnimal(id);
            return Ok(id.ToString());
        }
    }
}