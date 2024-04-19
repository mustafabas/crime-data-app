using CrimeData.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeData.Entities
{
    public class City:BaseEntity
    {
        public int ApiSourceId { get; set;  }
        public string Name { get; set; }
        public virtual ApiSource ApiSource { get; set; }

    }
}
