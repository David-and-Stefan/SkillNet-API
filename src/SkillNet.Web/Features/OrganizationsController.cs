using Microsoft.AspNetCore.Mvc;
using SkillNet.Application.Common.Pagination.Abstractions;
using SkillNet.Application.Organizations.Commands.Create;
using SkillNet.Application.Organizations.Queries.Common;
using SkillNet.Application.Organizations.Queries.Details;
using SkillNet.Application.Organizations.Queries.Search;

namespace SkillNet.Web.Features
{
    [Route("o")]
    public class OrganizationsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IPage<OrganizationOutputModel>>> Search([FromQuery] SearchOrganizationsQuery orgQuery)
            => await this.Send(orgQuery);
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationDetailsOutputModel>> Details([FromRoute] DetailsOrganizationQuery orgQuery)
            => await this.Send(orgQuery);

        [HttpPost("create")]
        public async Task<ActionResult<CreateOrganizationOutputModel>> Create(
            [FromBody] CreateOrganizationCommand command) => await this.Send(command);
    }
}
