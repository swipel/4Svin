﻿using System;
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
        
        [HttpGet("{farmId}/{barnNumber}")]
        public ActionResult Get(int farmId, int barnNumber)
        {
            var boxes = _apiManager.GetAllBoxesByBarnId(farmId, barnNumber).ToList();
            if (boxes.Count > 0)
            {
                return Ok(boxes);
            }
            return NotFound("No item found");
        }
        
        [HttpGet("{farmId}/{barnNumber}/{boxNumber}")]
        public ActionResult Get(int farmId, int barnNumber, int boxNumber)
        {
            var boxes = _apiManager.GetBoxById(farmId, barnNumber, boxNumber).ToList();
            if (boxes.Count > 0)
            {
                return Ok(boxes);
            }
            return NotFound("No item found");
        }
        
        //Get statistics
        [HttpGet("{farmId}/statistics")]
        public ActionResult Get(int farmId)
        {
            var boxes = _apiManager.GetStatistics(farmId).ToList();
            if (boxes.Count > 0)
            {
                return Ok(boxes);
            }
            return NotFound("No item found");
        }

        //Update box
        [HttpPut("{id}")]
        public ActionResult Put(BoxUpdate boxUpdate)
        {
            var success = _apiManager.ChangeBox(boxUpdate);
            if (success)
            {
                return Ok(success);
            }
            return NotFound("No item found");
        }
    }
}

