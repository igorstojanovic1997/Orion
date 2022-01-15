using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.Models;

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
            var contracts = _context.Contracts.Include(c=>c.ContractType).ToList();

            return View(contracts);
        }

        public ActionResult Details(int id)
        {
            var contract = _context.Contracts.SingleOrDefault(c=>c.Id == id);
            return View(contract);
        }

    }
}