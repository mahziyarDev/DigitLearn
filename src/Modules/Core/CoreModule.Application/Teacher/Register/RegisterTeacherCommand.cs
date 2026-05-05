using Common.Application;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Teacher.Register
{
    public record RegisterTeacherCommand(
        string UserName,
        IFormFile CvFile,
        Guid UserId
        ) : IBaseCommand;
}
