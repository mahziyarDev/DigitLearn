using Common.Query;
using CoreModule.Query.Teacher._DTOs;

namespace CoreModule.Query.Teacher.GetByUserId;

public record GetTeacherByUserIdQuery(Guid UserId) : IBaseQuery<TeacherDto?>;