using Common.Query;
using CoreModule.Query.Category._DTOs;

namespace CoreModule.Query.Category.GetById;

public record GetCourseCategoryByIdQuery(Guid CategoryId) : IBaseQuery<CourseCategoryDto?>;