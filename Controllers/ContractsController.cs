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
            var contractsList = _context.Contracts.Include(c => c.ContractPlans).ToList();

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


            return View(contractIndexDtos);
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
            var contractPlan = Mapper.Map<NewContractViewModel, ContractPlan>(viewModel);

            if (ModelState.IsValid)
            {
                if (viewModel.PlanIds != null)
                {
                    contractPlan.Contract.ContractPlans =
                        viewModel.PlanIds.Select(t => new ContractPlan
                        {
                            ContractId = viewModel.ContractId,
                            PlanId = t
                        }).ToList();
                }

                if (viewModel.Id == 0)
                {
                    contractPlan.Contract.DateTimeCreated = DateTime.Now;

                    _context.Contracts.Add(contractPlan.Contract);

                }
                else
                {
                    _context.ContractPlans.RemoveRange(
                        _context.ContractPlans.Where(t => t.ContractId == viewModel.ContractId));

                    _context.Contracts.AddOrUpdate(contractPlan.Contract);

                    foreach (var item in contractPlan.Contract.ContractPlans)
                    {
                        _context.ContractPlans.AddOrUpdate(item);
                    }
                    
                }


                _context.ContractHistories.Add(new ContractHistory
                {
                    DateTimeUpdated = DateTime.Now,
                    Active = viewModel.IsActive,
                    ContractId = viewModel.ContractId,
                    Sum = _context.Plans.Where(s => viewModel.PlanIds.Contains(s.Id)).Sum(t => t.Price)
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
            var contract = _context.Contracts.Include(c => c.ContractPlans).SingleOrDefault(c => c.Id == id);

            if (contract == null)
                return HttpNotFound();

            var viewmodel = Mapper.Map<Contract, NewContractViewModel>(contract);

            viewmodel.ContractHistoryDtos = _context.ContractHistories.
                Where(t => t.ContractId == viewmodel.ContractId).ToList()
                .Select(Mapper.Map<ContractHistory, ContractHistoryDto>);

            viewmodel.Plans = _context.Plans.ToList();
            return View("ContractsForm", viewmodel);
        }

    }
}