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
            var list = context.Farm.Where(a => a.FarmId.Equals(1)).Include(a => a.Barn).Include(b => b.Barn.Box());
            return list;
        }
    }
}