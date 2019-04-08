using System.Collections.Generic;
using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;
using ITI.PrimarySchool.WebApp.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class PlanningController : Controller
    {
        readonly PlanningGateway _planningGateway;

        public PlanningController( PlanningGateway planningGateway)
        {
            _planningGateway = planningGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanningList()
        {
            IEnumerable<PlanningData> result = await _planningGateway.GetAll();
            return Ok( result );
        }

        [HttpGet( "{id}", Name = "GetPlanning" )]
        public async Task<IActionResult> GetPlanningById( int id )
        {
            Result<PlanningData> result = await _planningGateway.FindById( id );
            return this.CreateResult( result );
        }
    }
}