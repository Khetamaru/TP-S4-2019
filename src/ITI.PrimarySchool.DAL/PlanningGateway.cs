using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ITI.PrimarySchool.DAL
{
    public class PlanningGateway
    {
        readonly string _connectionString;

        public PlanningGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<PlanningData>> GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<PlanningData>( @"select PlanningId, [Date], iti.vPlanning.TeacherId, TeacherName from iti.vPlanning;" );
            }
        }

        public async Task<Result<PlanningData>> FindById( int teacherId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                PlanningData planning = await con.QueryFirstOrDefaultAsync<PlanningData>(
                    @"select t.PlanningId, t.[Date], t.TeacherId, t.TeacherName from iti.vPlanning t where t.TeacherId = @TeacherId;",
                    new { TeacherId = teacherId } );
                if( planning == null ) return Result.Failure<PlanningData>( Status.NotFound, "Planning not found." );
                return Result.Success( planning );
            }
        }
    }
}
