using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Orion.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public byte DiscountRate { get; set; }
        public short Fee { get; set; }
        public byte GratisPeriod { get; set; }
        public byte Duration { get; set; }
        public DateTime? DateTimeCreated { get; set; }
        [InverseProperty("Contract")]
        public virtual ICollection<ContractPlan> ContractPlans { get; set; }
    }
}