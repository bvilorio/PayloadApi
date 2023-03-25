using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayloadApi.Models
{
    public class Robot
    {
        public int RobotId { get; set; }

        public int BatteryLevel { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public double? DistanceToPayload { get; set; }
    }
}
