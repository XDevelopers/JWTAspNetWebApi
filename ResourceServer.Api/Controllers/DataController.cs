using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace ResourceServer.Api.Controllers
{
    public class DataController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/all")]
        public IHttpActionResult Get()
        {
            return Ok($"Now server time is:{DateTime.Now.ToString()}");
        }

        [CustomAuthorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;

            return Ok($"The current user is: {identity.Name}");
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorized")]
        public IHttpActionResult GetForAuthorizated()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            return Ok($"The current User is: {identity.Name} " +
                $"and he is using the Role: {string.Join(",", roles)}");
        }
    }
}