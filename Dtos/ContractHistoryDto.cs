using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion.Dtos
{
    public class ContractHistoryDto
    {
        public bool Active { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public float Sum { get; set; }
    }
}