using Common.Query;
using CoreModule.Query.Course._DTOs;

namespace CoreModule.Query.Course.GetById;

public record GetCourseByIdQuery(Guid Id) : IBaseQuery<CourseDto?>;