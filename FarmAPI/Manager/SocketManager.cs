using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmAPI.Models;
using FarmAPI.WebSocket;
using Microsoft.EntityFrameworkCore;
using Type = FarmAPI.Models.TypeEnum;

namespace FarmAPI.Manager
{
    public class SocketManager
    {
        ApiSocket socket = new ApiSocket();

        public void FeedAnimal(Farm farm)
        {
         //TODO FEED
            var feedStatus = socket.FeedAnimal(new SocketMessage(Type.Feed, farm));
            //TODO Check feed status and transform to a short need data from ls
            
            //LogFeeding(farmId, 1);
        }

        private void LogFeeding(int farmId, short state)
        {
            var context = new SvinSkoleContext();
            var foodLog = new FeedLog{FarmId = farmId, Logtime = new DateTime (), State = state};
            context.Add(foodLog);
            context.SaveChanges();
        }
    }
}