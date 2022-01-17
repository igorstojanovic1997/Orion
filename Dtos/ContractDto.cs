using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orion.Models;

namespace Orion.Dtos
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public byte ContractTypeId { get; set; }
    }
}