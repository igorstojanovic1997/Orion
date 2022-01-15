using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion.Models
{
    public class ContractHistory
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public bool Active { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public Contract Contract { get; set; }
    }
}