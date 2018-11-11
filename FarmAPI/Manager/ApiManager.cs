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
        private readonly SocketManager _socketManager = new SocketManager();

        public IEnumerable<Farm> GetAllFarms()
        {
            var context = new SvinSkoleContext();
                var list = context.Farm.Include(a => a.Barn).ThenInclude(b => b.Box);
                return list;
        }
        
        public IEnumerable<Box> GetStatistics(int farmId)
        {
            var context = new SvinSkoleContext();
            var list = context.Box.Where(a => a.FarmId == farmId).Include(b => b.SensorBox).ThenInclude(c => c.Sensor).ThenInclude(d => d.SensorValue);
            return list;
        }

        public void FeedAnimal(int farmId)
        {
            _socketManager.FeedFarm(farmId);
        }

        public Boolean ChangeBox(int animalAmount, int type, int boxNumber, int barnNumber, int farmId)
        {
            var context = new SvinSkoleContext();
            var boxes = context.Box.Where(a => a.BoxNumber == boxNumber).Where(b => b.BarnNumber == barnNumber).Where(c => c.FarmId == farmId).ToList();
            if (boxes.Count <= 0) return false;
            boxes[0].AnimalAmount = animalAmount;
            boxes[0].BoxType = type;
            context.Entry(boxes[0]);
            context.SaveChanges();
            return true;
        }
    }
}