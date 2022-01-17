using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.Dtos;
using Orion.Models;
using Orion.ViewModels;

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

            var contractsList = _context.Contracts.Include(c => c.ContractPlans)
                .OrderByDescending(t => t.DateTimeCreated).Take(5).ToList();

            var contractIndexDtos = contractsList.Select(t => new ContractIndexDto
            {
                ContractId = t.Id,
                Username = t.Username,
                IsActive = t.IsActive,
                GratisPeriod = t.GratisPeriod,
                DiscountRate = t.DiscountRate,
                Duration = t.Duration,
                PlanNames = string.Join(",", t.ContractPlans.Select(s => s.Plan.Name))
            }).ToList();

            //https://stackoverflow.com/questions/38304710/how-to-select-last-record-in-a-linq-groupby-clause

            var contractProfit = _context.ContractHistories
                .Include(c => c.Contract).GroupBy(grp => grp.ContractId)
                .Select(g => g.OrderByDescending(c => c.Id).FirstOrDefault())
                .Select(t => new ContractProfitDto
                {
                    ContractId = t.ContractId,
                    Profit = t.Sum * t.Contract.Duration
                }).ToList();


            var viewModel = new HomeViewModel()
            {
                ContractStatusDtos = dtoList,
                LastFiveContractPlans = contractIndexDtos,
                ContractProfitDtos = contractProfit
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

           

            return View();
        }

        
        public ActionResult Delete(int id)
        {
            var contract = _context.Contracts.SingleOrDefault(c => c.Id == id);

            if (contract == null)
                return HttpNotFound();

            _context.Contracts.Remove(contract);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}