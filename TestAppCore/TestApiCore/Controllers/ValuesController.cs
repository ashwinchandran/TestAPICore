using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApiCore.Objects;

namespace TestApiCore.Controllers
{
   //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult Get(int id,
            [FromHeader(Name = "Accept")]string accept)
        {
            var item = new Person();

            if (accept.EndsWith("hateoas"))
            {
                var link = new LinkHelper<Person>(item);
                link.Links.Add(new Link
                {
                    Href = Url.Link("GetPerson", new { item.Id }),
                    Rel = "self",
                    method = "GET"
                });
                link.Links.Add(new Link
                {
                    Href = Url.Link("PutPerson", new { item.Id }),
                    Rel = "put-person",
                    method = "PUT"
                });
                link.Links.Add(new Link
                {
                    Href = Url.Link("DeletePerson", new { item.Id }),
                    Rel = "delete-person",
                    method = "DELETE"
                });
                return new ObjectResult(link);
            }
            return new ObjectResult(item);
        }

        //// GET api/values/5
        //[HttpGet("{id}", Name = "GetPerson")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpGet("{id}", Name = "PostTodo")]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        [HttpPut("{id}", Name = "PutPerson")]
        public void Put(int id, [FromBody] string value)
        {
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}", Name = "DeletePerson")]
        public void Delete(int id)
        {
        }
    }
}
