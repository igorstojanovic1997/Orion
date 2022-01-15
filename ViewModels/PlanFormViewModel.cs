using System.ComponentModel.DataAnnotations;
using Orion.Enums;

namespace Orion.ViewModels
{
    public class PlanFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
        public PlanCategory Category { get; set; }
    }
}