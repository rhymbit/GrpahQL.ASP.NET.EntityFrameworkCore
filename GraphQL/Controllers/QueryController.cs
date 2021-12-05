using static System.Console;
using EntityGraphQL;
using EntityGraphQL.Schema;
using GraphQLDatabase;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GraphQL.Controllers
{
    [Route("graphql")]
    public class QueryController : Controller
    {
        private readonly DemoContext _dbContext;
        private readonly SchemaProvider<DemoContext> _schemaProvider;

        public QueryController(DemoContext dbContext, SchemaProvider<DemoContext> schemaProvider)
        {
            _dbContext = dbContext;
            _schemaProvider = schemaProvider;
        }

        // GET: /graphql
        [HttpPost("_")]
        public object GetGraphQL([FromBody] QueryRequest query)
        {
            try
            {
                var results = _schemaProvider.ExecuteQuery(query, _dbContext, HttpContext.RequestServices, null);
                // gql compile errors show up in results.Errors
                return results;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }


        // GET: /graphql/get-movie
        [HttpGet("get-movie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            
            var results = await _dbContext.Movies.FindAsync(id); 

            return results != null ? 
                Ok(results) :
                NotFound();
        }

        // POST: /graphql/create-movie
        [HttpPost("create-movie")]
        public async Task<IActionResult> CreateMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (movie == null)
            {
                return BadRequest();
            }

            await _dbContext.Movies.AddAsync(movie);

            int affected = await _dbContext.SaveChangesAsync();

            return affected == 1 ?
                 Created($"/graphql/get-movie/{movie.Id}", movie) :
                 Problem("Something went wrong at the server");
        }
    }
}
