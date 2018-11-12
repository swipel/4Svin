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
                var list = context.Farm;
                return list;
        }
        
        public IEnumerable<Barn> GetAllBarnsByFarmId(int farmId)
        {
            var context = new SvinSkoleContext();
            var list = context.Barn.Where(a => a.FarmId == farmId);
            return list;
        }
        
        public IEnumerable<Box> GetAllBoxesByBarnId(int farmId, int barnNumber)
        {
            var context = new SvinSkoleContext();
            var list = context.Box.Where(a => a.FarmId == farmId).Where(b => b.BarnNumber == barnNumber);
            return list;
        }
        
        public IEnumerable<Box> GetStatistics(int farmId)
        {
            var context = new SvinSkoleContext();
            var list = context.Box.Where(a => a.FarmId == farmId).Include(b => b.SensorBox).ThenInclude(c => c.Sensor)
                .ThenInclude(d => d.SensorValue);
            
            return list;
        }

        public void FeedAnimal(int farmId)
        {
            var context = new SvinSkoleContext();
            var farms = context.Farm.Where(a => a.FarmId == farmId).ToList();
            _socketManager.FeedAnimal(farms.FirstOrDefault());
        }

        public Boolean ChangeBox(BoxUpdate box)
        {
            var context = new SvinSkoleContext();
            var boxes = context.Box.Where(a => a.BoxNumber == box.BoxNumber).Where(b => b.BarnNumber == box.BarnNumber).Where(c => c.FarmId == box.FarmId).ToList();
            if (boxes.Count <= 0) return false;
            boxes[0].AnimalAmount = box.AnimalAmount;
            boxes[0].BoxType = box.Type;
            context.Entry(boxes[0]);
            context.SaveChanges();
            return true;
        }
    }
}