using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmAPI.Manager
{
    public class ApiManager
    {
        public IEnumerable<Farm> getAllFarms()
        {
            var context = new SvinSkoleContext();
                var list = context.Farm.Include(a => a.Barn).ThenInclude(b => b.Box).ThenInclude(c => c.SensorBox)
                    .ThenInclude(d => d.Sensor).ThenInclude(e => e.SensorValue);
                return list;
        }

        public Boolean FeedAnimal(int farmId)
        {
            return true;
        }
    }
}