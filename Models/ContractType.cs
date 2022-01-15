using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace Orion.Models
{
    public class ContractType
    {
        public byte Id { get; set; }
        [Required]
        public byte Duration { get; set; }
        public byte DiscountRate { get; set; }
        public short Fee { get; set; }
        public byte GratisPeriod { get; set; }
    }
}