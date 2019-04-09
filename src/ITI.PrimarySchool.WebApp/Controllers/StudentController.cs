using System.Collections.Generic;
using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;
using ITI.PrimarySchool.WebApp.Authentication;
using ITI.PrimarySchool.WebApp.Models.StudentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class StudentController : Controller
    {
        readonly StudentGateway _studentGateway;

        public StudentController( StudentGateway studentGateway )
        {
            _studentGateway = studentGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            IEnumerable<StudentData> result = await _studentGateway.GetAll();
            return Ok( result );
        }

        [HttpGet( "{id}", Name = "GetStudent" )]
        public async Task<IActionResult> GetStudentById( int id )
        {
            Result<StudentData> result = await _studentGateway.FindById( id );
            return this.CreateResult( result );
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent( [FromBody] StudentViewModel model)
        {
            Result<int> result;

            if(model.ClassId == 0) {
                result = await _studentGateway.Create( model.FirstName, model.LastName, model.BirthDate, model.GitHubLogin );
            } else {
                result = await _studentGateway.Create( model.FirstName, model.LastName, model.BirthDate, model.GitHubLogin, model.ClassId );
            }
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetStudent";
                o.RouteValues = id => new { id };
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateStudent( int id, [FromBody] StudentViewModel model )
        {
            Result result;

            result = await _studentGateway.Update( id, model.FirstName, model.LastName, model.BirthDate, model.GitHubLogin);

            return this.CreateResult( result );
        }

        [HttpPut( "assignClass/{id}" )]
        public async Task<IActionResult> ClassAssignStudentAsync(int id, [FromBody] StudentViewModel model )
        {
            Result result;

            result = await _studentGateway.AssignClass(model.StudentId, model.ClassId);

            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteStudent( int id )
        {
            Result result = await _studentGateway.Delete( id );
            return this.CreateResult( result );
        }
    }
}
