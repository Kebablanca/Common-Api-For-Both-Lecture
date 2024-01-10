using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSData.Entities
{
    public class Alarms : BaseEntity
    {
        public DateTime AlarmTime { get; set; }
        public int Day { get; set; }
        public bool IsSet { get; set; }

        public int UserId { get; set; }
    }
}
