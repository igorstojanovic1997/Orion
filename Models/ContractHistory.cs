using System;

namespace Orion.Models
{
    public class ContractHistory
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public float Sum { get; set; }
        public bool Active { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public Contract Contract { get; set; }
    }
}