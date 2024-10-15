using Microsoft.AspNetCore.Mvc;
using SkillNet.Application.Organizations.Commands.Create;

namespace SkillNet.Web.Features
{
    [Route("o")]
    public class OrganizationsController : ApiController
    {
        [HttpPost("create")]
        public async Task<ActionResult<CreateOrganizationOutputModel>> Create(
            [FromBody] CreateOrganizationCommand command) => await this.Send(command);
    }
}
