﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSData.Entities
{
    public class User:BaseEntity
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

    }
}
