using Common.Application;
using CoreModule.Domain.TeacherAgg.Repository;

namespace CoreModule.Application.Teacher.Accept;

public class AcceptTeacherRequestCommandHandler : IBaseCommandHandler<AcceptTeacherRequestCommand>
{
    private readonly ITeacherRepository _teacherRepository;
    /// <summary></summary>
    /// <param name="teacherRepository"></param>
    public AcceptTeacherRequestCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<OperationResult> Handle(AcceptTeacherRequestCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetTracking(request.TeacherId);
        if (teacher == null)
        {
            return OperationResult.NotFound("teacher not found");
        }
        teacher.AccessptRequest();
        await _teacherRepository.Save();
        return OperationResult.Success();
    }
}