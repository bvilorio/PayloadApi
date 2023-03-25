using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayloadApi.Models
{
    public class PayloadResponse
    {
        public int RobotId { get; set; }

        public double DistanceToGoal { get; set; }

        public int BatteryLevel { get; set; }

    }
}
