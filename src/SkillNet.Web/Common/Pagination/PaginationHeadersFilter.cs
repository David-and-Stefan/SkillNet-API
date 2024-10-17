namespace SkillNet.Web.Common.Pagination
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SkillNet.Application.Common.Pagination.Abstractions;

    public class PaginationHeadersFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult
                && objectResult.Value is IPage page)
            {
                context.HttpContext.Response.Headers.AddPaginationHeader(
                    page.CurrentPage,
                    page.PageSize,
                    page.TotalCount);
            }

            await next();
        }
    }
}
