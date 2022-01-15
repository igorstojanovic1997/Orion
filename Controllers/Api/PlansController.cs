using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Orion.Dtos;
using Orion.Models;

namespace Orion.Controllers.Api
{
    public class PlansController : ApiController
    {
        private ApplicationDbContext _context;

        public PlansController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetPlans()
        {
            var dtos = _context.Plans
                .ToList()
                .Select(Mapper.Map<Plan, PlanDto>);

            return Ok(dtos);
        }
        [HttpDelete]
        public IHttpActionResult DeletePlan(int id)
        {
            var planInDb = _context.Plans.SingleOrDefault(c => c.Id == id);

            if (planInDb == null)
                return NotFound();

            _context.Plans.Remove(planInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
