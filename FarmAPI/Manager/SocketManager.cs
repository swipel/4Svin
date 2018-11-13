using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmAPI.Models;
using FarmAPI.WebSocket;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Type = FarmAPI.Models.TypeEnum;

namespace FarmAPI.Manager
{
    public class SocketManager
    {
        private readonly ApiSocket _socket = new ApiSocket();

        //Feed whole farm
        public void FeedAnimal(Farm farm)
        {
            try
            {
                //Call socket to feed animal and wait for answear
                var feedStatus = _socket.FeedAnimal(new SocketMessage(Type.Feed, farm.FarmId));

                //Deserializa json object to socketFeedResponse
                SocketFeedResponse feedResponse = JsonConvert.DeserializeObject<SocketFeedResponse>(feedStatus);

                //Log to db
                LogFeeding(feedResponse.FarmId, Convert.ToInt16(feedResponse.Status));
            }
            catch (Exception e)
            {
                //TODO LOG ERROR TO DB
            }
        }

        private void LogFeeding(int farmId, short state)
        {
            var context = new SvinSkoleContext();
            var foodLog = new FeedLog {FarmId = farmId, Logtime = DateTime.Now, State = state};
            context.Add(foodLog);
            context.SaveChanges();
        }

        //Ask for statistics from ls
        public void StatisticsFromLs(int farmId, int sensorId)
        {
            //Call socket to ask for statistics
            var statistics = _socket.Statistics(new SocketMessage(Type.Statistics, farmId, sensorId));
            //DeserializeObject
            //Log statistics to db
            LogStatistics();
        }

        private void LogStatistics()
        {
            //TODO Log statistics
        }
    }
}