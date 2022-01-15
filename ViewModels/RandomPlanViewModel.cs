using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orion.Models;

namespace Orion.ViewModels
{
    public class RandomPlanViewModel
    {
        public Plan Plan { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}