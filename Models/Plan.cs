using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Orion.Enums;

namespace Orion.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public PlanCategory Category { get; set; }
        [InverseProperty("Plan")]
        public virtual ICollection<ContractPlan> ContractPlans { get; set; }
    }
}