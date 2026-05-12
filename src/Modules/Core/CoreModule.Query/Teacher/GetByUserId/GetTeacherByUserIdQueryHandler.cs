using Common.Query;
using CoreModule.Query._Data;
using CoreModule.Query._DTOs;
using CoreModule.Query.Teacher._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Teacher.GetByUserId;

class GetTeacherByUserIdQueryHandler : IBaseQueryHandler<GetTeacherByUserIdQuery, TeacherDto?>
{
    private readonly QueryContext _context;
    /// <summary></summary>
    /// <param name="context"></param>
    public GetTeacherByUserIdQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<TeacherDto?> Handle(GetTeacherByUserIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Teachers
            .Include(c => c.User)
            .FirstOrDefaultAsync(f => f.UserId == request.UserId, cancellationToken: cancellationToken);

        if (model == null)
        {
            return null;
        }

        return new TeacherDto
        {
            Id = model.Id,
            CreationDate = model.CreationDate,
            UserName = model.UserName,
            CvFileName = model.CvFileName,
            Status = model.Status,
            User = new CoreModuleUserDto
            {
                Id = model.User.Id,
                CreationDate = model.User.CreationDate,
                Avatar = model.User.Avatar,
                Name = model.User.Name,
                Family = model.User.Family,
                Email = model.User.Email,
                PhoneNumber = model.User.PhoneNumber
            }
        };
    }
}