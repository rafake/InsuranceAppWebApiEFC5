﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAppWebApi.Domain
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InsureeId { get; set; }
    }
}
