using Newtonsoft.Json;
using PayloadApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PayloadApi
{
    public class RobotManager
    {

        RobotProvidercs _robotProvider;
        public RobotManager()
        {
            _robotProvider = new RobotProvidercs();
        }

        public string GetRobots() 
        {
            return _robotProvider.GetRobots();
        }

        //Deserialize the Robots jSON
        public IEnumerable<Robot> GetDeserializedRobots() 
        {

            return JsonConvert.DeserializeObject<List<Robot>>(_robotProvider.GetRobots()); ;
   
        }

        //Logic for returning the right payload
        public PayloadResponse GetNearestRobot(IEnumerable<Robot> robots, Payload payload) 
        {
            var robotDistanceFromPayload = 0.0;
            var closestDistance = 0.0;
            Robot closestRobot = null;
            List<Robot> closeByRobots = new List<Robot>();

            foreach (Robot robot in robots) 
            {

                robotDistanceFromPayload = CalculateDistance(robot.X, robot.Y, payload.X, payload.Y);
                if (closestDistance == 0.0 || robotDistanceFromPayload < closestDistance)
                {
                    closestDistance = robotDistanceFromPayload;
                    if (robotDistanceFromPayload <= 10) 
                    {
                        robot.DistanceToPayload = robotDistanceFromPayload;
                        closeByRobots.Add(robot);   
                    }
                    closestRobot = robot;
                }
            }

            //if there are more than 1 < 10 distance check for battery 
            if (closeByRobots.Count > 1) 
            {
                closestRobot = closeByRobots.ElementAt(0);

                foreach (Robot robotCloseBy in closeByRobots) 
                {
                    if (robotCloseBy.BatteryLevel > closestRobot.BatteryLevel) 
                    {
                        closestRobot = robotCloseBy;
                    }
                }
            }

            var payloadResponse = new PayloadResponse() 
            {BatteryLevel = closestRobot.BatteryLevel, DistanceToGoal = (double)closestRobot.DistanceToPayload, RobotId = closestRobot.RobotId};

            return payloadResponse;
        }

        public double CalculateDistance(double x1, double y1, double x2, double y2) 
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        } 



    }
}
