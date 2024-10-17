namespace SkillNet.Application.Common.Pagination
{
    using SkillNet.Application.Common.Pagination.Abstractions;

    public static class PagedListExtensions
    {
        public static IPage<T> ToPage<T>(this IPagedList<T> pagedList) => new Page<T>(
            pagedList.Items,
            pagedList.PageIndex,
            pagedList.PageSize,
            (int)pagedList.TotalCount);
    }
}
