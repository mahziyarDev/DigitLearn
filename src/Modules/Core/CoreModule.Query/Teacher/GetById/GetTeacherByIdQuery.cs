using Common.Query;
using CoreModule.Query.Teacher._DTOs;

namespace CoreModule.Query.Teacher.GetById;

public record GetTeacherByIdQuery(Guid Id) : IBaseQuery<TeacherDto?>;