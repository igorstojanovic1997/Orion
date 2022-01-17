using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion.Dtos
{
    public class ContractIndexDto
    {
        public int ContractPlanId { get; set; }
        public int ContractId { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public byte DiscountRate { get; set; }
        public byte GratisPeriod { get; set; }
        public byte Duration { get; set; }
        public string PlanNames { get; set; }
    }
}