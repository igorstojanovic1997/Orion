using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orion.Dtos;
using Orion.Models;

namespace Orion.ViewModels
{
    public class NewContractViewModel
    {
        public int Id { get; set; }
        [Required]
        public int[] PlanIds { get; set; }
        public int ContractId { get; set; }
        [Required]
        public string Username { get; set; }
        public bool IsActive { get; set; }
        [Range(1, 100, ErrorMessage = "Range must be 1-100")]
        public byte DiscountRate { get; set; }
        public short Fee { get; set; }
        public byte GratisPeriod { get; set; }
        [Utilities.Utilities.WhiteList(12, 24)]
        public byte Duration { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public DateTime? DateTimeCreated { get; set; }

        public IEnumerable<ContractHistoryDto> ContractHistoryDtos { get; set; }

        public NewContractViewModel()
        {
            IsActive = true;
        }
    }
}