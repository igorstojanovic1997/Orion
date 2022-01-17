using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orion.Enums;

namespace Orion.ViewModels
{
    public class PlanFormViewModel : IValidatableObject
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public float Price { get; set; }
        
        public string Description { get; set; }
        public PlanCategory Category { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                results.Add(new ValidationResult("Name is required", new List<string>{nameof(Name)}));
            }

            return results;
        }
    }
}