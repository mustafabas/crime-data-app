﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeData.Entities.Tables
{
    public class ApiSource:BaseEntity
    {
        public string CountryCode { get; set; }
        public string ServiceEndpoint { get; set; }
    }
}
