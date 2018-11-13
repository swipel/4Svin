using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using FarmAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FarmAPI.Manager
{
    public class ApiManager
    {
        private readonly SocketManager _socketManager = new SocketManager();

        //Returns list of all farms
        public IEnumerable<Farm> GetAllFarms()
        {
            var context = new SvinSkoleContext();
                var list = context.Farm;
                return list;
        }
        
        //Return object farm
        public IEnumerable<Barn> GetAllBarnsByFarmId(int farmId)
        {
            var context = new SvinSkoleContext();
            var list = context.Barn.Where(a => a.FarmId == farmId);
            return list;
        }
        
        //Return object barn
        public IEnumerable<Box> GetAllBoxesByBarnId(int farmId, int barnNumber)
        {
            var context = new SvinSkoleContext();
            var list = context.Box.Where(a => a.FarmId == farmId).Where(b => b.BarnNumber == barnNumber);
            return list;
        }
        
        //Return object box
        public IEnumerable<BoxFormat> GetBoxById(int farmId, int barnNumber, int boxNumber)
        {
            var context = new SvinSkoleContext();
            //SQL statement with 1 join and 3 where statement to be sure only get the right box and boxtype
            var list = (from p in context.Box
                join e in context.BoxType 
                on p.BoxType equals e.BoxTypeId 
                where p.FarmId == farmId
                where p.BarnNumber == barnNumber
                where p.BoxNumber == boxNumber
                select new BoxFormat
                      {
                          FarmId = p.FarmId,
                          BarnNumber = p.BarnNumber,
                          BoxNumber = p.BoxNumber,
                          AnimalAmount = p.AnimalAmount,
                          BoxTypeId = p.BoxType,
                          BoxType = e.Type
                      }).ToList();   
            return list;
        }
        
        public IEnumerable<StatisticsFormat> GetStatistics(int farmId)
        {
            var context = new SvinSkoleContext();
            //Sql statement 3 join and 1 where to get statistics pr farm (In future probably limit 10 days back)
            var statisticsList = (from sBox in context.SensorBox
                join s in context.Sensor 
                    on sBox.SensorId equals s.SensorId
                join sValue in context.SensorValue 
                    on s.SensorId equals sValue.SensorId
                join sType in context.SensorType
                    on s.SensorTypeId equals sType.SensorTypeId
                where sBox.FarmId == farmId
                select new StatisticsFormat
                {
                    FarmId = sBox.FarmId,
                    BarnNumber = sBox.BarnNumber,
                    BoxNumber = sBox.BoxNumber,
                    Type = sType.Type,
                    TypeId = s.SensorId,
                    SensorValue = sValue.Value,
                    LogTime = sValue.LogTime 
                }).ToList();  
            
            return statisticsList;
        }

        //Feed animal 
        //Flow Controller -> here -> SocketManager -> apiSocket -> (LocalServer)Socket
        //Flow back    (LocalServer)Socket -> apiSocket -> socketManager -> saveDb
        public IEnumerable<Farm> FeedAnimal(int farmId)
        {
            var context = new SvinSkoleContext();
            var farms = context.Farm.Where(a => a.FarmId == farmId).ToList();
             _socketManager.FeedAnimal(farms.FirstOrDefault());
            return farms;
        }

        //Update box AnimalAmount and boxtype
        public bool ChangeBox(BoxUpdate box)
        {
            var context = new SvinSkoleContext();
            var boxes = context.Box.Where(a => a.BoxNumber == box.BoxNumber).Where(b => b.BarnNumber == box.BarnNumber).Where(c => c.FarmId == box.FarmId).ToList();
            if (boxes.Count <= 0) return false;
            boxes[0].AnimalAmount = box.AnimalAmount;
            boxes[0].BoxType = box.BoxType;
            context.Entry(boxes[0]);
            context.SaveChanges();
            return true;
        }
    }
}