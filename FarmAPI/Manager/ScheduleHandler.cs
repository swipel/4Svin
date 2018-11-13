using System.Collections.Generic;
using System.Linq;
using FarmAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmAPI.Manager
{
    public class ScheduleHandler
    {
        // NOT IMPLEMENT \\
        // TODO Other thread on program launch maybe a event listener
        // TODO Call socketManager statistics

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