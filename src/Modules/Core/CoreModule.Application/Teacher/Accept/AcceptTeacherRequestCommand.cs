using Common.Application;
using FluentValidation;

namespace CoreModule.Application.Teacher.Accept;

public record AcceptTeacherRequestCommand
    (Guid TeacherId)
    : IBaseCommand;

