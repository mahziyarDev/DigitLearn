using Common.Query;
using CoreModule.Query.Course._DTOs;

namespace CoreModule.Query.Course.GetBySlug;

public record GetCourseBySlugQuery(string Slug) : IBaseQuery<CourseDto?>;