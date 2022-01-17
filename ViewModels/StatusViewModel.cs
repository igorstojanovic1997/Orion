using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orion.Dtos;
using Orion.Models;

namespace Orion.ViewModels
{
    public class HomeViewModel
    {
        public List<ContractStatusDto> ContractStatusDtos { get; set; }
        public List<ContractIndexDto> LastFiveContractPlans { get; set; }
        public List<ContractProfitDto> ContractProfitDtos { get; set; }
    }
}