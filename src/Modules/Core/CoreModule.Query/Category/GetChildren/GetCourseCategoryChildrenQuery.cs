using Common.Query;
using CoreModule.Query.Category._DTOs;

namespace CoreModule.Query.Category.GetChildren;

public record GetCourseCategoryChildrenQuery(Guid ParentId) : IBaseQuery<List<CourseCategoryDto>>;