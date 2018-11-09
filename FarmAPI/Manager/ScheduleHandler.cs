using System.Collections.Generic;
using System.Linq;
using FarmAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmAPI.Manager
{
    public class ScheduleHandler
    {
        //TODO Skal ligge på en anden tråd og køres ved start af programmet

        public List<Schedule> GetSiloSensorSchedule()
        {
            var context = new SvinSkoleContext();
            var siloSchedules = context.Schedule.ToList();
            return siloSchedules;
        }
        
        public List<Sensor> GetBoxSensorSchedule()
        {
            var context = new SvinSkoleContext();
            var boxSensorSchedules = context.Sensor.ToList();
            return boxSensorSchedules;
        }

        public void CreateScheduleThreads()
        {
            var temp = GetSiloSensorSchedule();
            
            
        }
        
    }
}