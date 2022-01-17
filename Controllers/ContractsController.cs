using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Orion.Dtos;
using Orion.Models;
using Orion.ViewModels;

namespace Orion.Controllers
{
    public class ContractsController : Controller
    {
        private ApplicationDbContext _context;

        public ContractsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: Contracts
        public ActionResult Index() 
        {
            var contracts = _context.ContractPlans.Include(c=>c.Contract).Include(t => t.Plan).ToList();

            return View(contracts);
        }

        public ActionResult New()
        {
            var viewmodel = new NewContractViewModel
            {
                Plans = _context.Plans.ToList()
            };

            return View("ContractsForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(NewContractViewModel viewModel)
        {
            
            //viewModel.Plans = _context.Plans.Where(t => t.Id == viewModel.PlanId).ToList();

            var contractPlan = Mapper.Map<NewContractViewModel, ContractPlan>(viewModel);

            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    contractPlan.Contract.DateTimeCreated = DateTime.Now;
                    
                    _context.ContractPlans.Add(contractPlan);
                }
                else
                {
                    _context.Contracts.AddOrUpdate(contractPlan.Contract);
                    _context.ContractPlans.AddOrUpdate(contractPlan);
                }

                _context.ContractHistories.Add(new ContractHistory
                {
                    DateTimeUpdated = DateTime.Now,
                    Active = viewModel.IsActive,
                    ContractId = viewModel.ContractId,
                    PlanId = viewModel.PlanId
                });

                _context.SaveChanges();
                return RedirectToAction("Index", "Contracts");
            }

            viewModel.Plans = _context.Plans.ToList();

            return View("ContractsForm", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contract = _context.ContractPlans.Include(c => c.Contract).Include(m => m.Plan).SingleOrDefault(c => c.Id == id);

            if (contract == null)
                return HttpNotFound();

            var viewmodel = Mapper.Map<ContractPlan, NewContractViewModel>(contract);

            viewmodel.ContractHistoryDtos = _context.ContractHistories.
                Where(t => t.ContractId == viewmodel.ContractId).ToList()
                .Select(Mapper.Map<ContractHistory, ContractHistoryDto>);

            viewmodel.Plans = _context.Plans.ToList();
            return View("ContractsForm", viewmodel);
        }
    }
}