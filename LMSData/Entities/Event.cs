using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSData.Entities
{
    public class Event:BaseEntity
    {
        public string? Title { get; set; }
        public DateTime? Date { get; set; }

        public int? UserId { get; set; }
    }
}
