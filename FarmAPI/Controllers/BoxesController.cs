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
    public class BoxesController : ControllerBase
    {
        private readonly ApiManager _apiManager = new ApiManager();
        
        //Get statistics
        [HttpGet("{farmId}/statistics")]
        public ActionResult Get(int farmId)
        {
            var boxes = _apiManager.GetStatistics(farmId).ToList();
            if (boxes.Count > 0)
            {
                return Ok(boxes);
            }

            return NotFound("Fail");
        }

        //Update box
        [HttpPut("{id}")]
        //public ActionResult Put(int amount, int type, int boxNumber, int barnNumber, int farmId)
        public ActionResult Put(BoxUpdate boxUpdate)
        {
            var success = _apiManager.ChangeBox(boxUpdate);
            if (success)
            {
                return Ok(success);
            }

            return NotFound("Fail");
        }
    }
}

