using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orion.Models
{
    public class Contract
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public ContractType ContractType { get; set; }
        public byte ContractTypeId { get; set; }
    }
}