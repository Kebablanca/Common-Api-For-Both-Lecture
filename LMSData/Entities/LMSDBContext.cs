using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSData.Entities
{
    public class LMSDBContext:DbContext
    {
        public LMSDBContext(DbContextOptions<LMSDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Alarms> Alarms { get; set; }
    }
}
