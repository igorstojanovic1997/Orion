using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.Dtos;
using Orion.Models;

namespace Orion.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var active = _context.Contracts.Count(t => t.IsActive);
            var inactive = _context.Contracts.Count(t => !t.IsActive);

            var dtoList = new List<ContractStatusDto>()
            {
                new ContractStatusDto()
                {
                    ActiveContracts = active,
                    InactiveContracts = inactive
                }
            };

            var lastFiveContracts = _context.ContractPlans.Include(c => c.Contract).Include(t => t.Plan)
                .OrderByDescending(t => t.Contract.DateTimeCreated).Take(5).ToList();


            return View();
        }
    }
}