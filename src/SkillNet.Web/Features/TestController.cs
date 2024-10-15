using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkillNet.Web.Features
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Authorize]
        public IActionResult Test() => Ok();
    }
}
