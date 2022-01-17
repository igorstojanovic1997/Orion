using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion.Dtos
{
    public class ContractStatusDto
    {
        public int ActiveContracts { get; set; }
        public int InactiveContracts { get; set; }
    }
}