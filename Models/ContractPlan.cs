using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace Orion.Models
{
    public class ContractPlan
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int PlanId { get; set; }
        [ForeignKey("ContractId")]
        [InverseProperty("ContractPlans")]
        public virtual Contract Contract { get; set; }

        [ForeignKey("PlanId")]
        [InverseProperty("ContractPlans")]
        public virtual Plan Plan { get; set; }
    }
}