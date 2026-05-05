using Common.Application;
using Common.Application.FileUtil.Interfaces;
using CoreModule.Application._Utilities;
using CoreModule.Domain.TeacherAgg.DomainService;
using CoreModule.Domain.TeacherAgg.Repository;

namespace CoreModule.Application.Teacher.Register;

public class RegisterTeacherCommandHandler : IBaseCommandHandler<RegisterTeacherCommand>
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly ITeacherDomainService _teacherDomainService;
    private readonly ILocalFileService _localFileService;
       
    /// <summary></summary>
    /// <param name="teacherRepository"></param>
    /// <param name="teacherDomainService"></param>
    /// <param name="localFileService"></param>
    public RegisterTeacherCommandHandler(ITeacherRepository teacherRepository, ITeacherDomainService teacherDomainService, ILocalFileService localFileService)
    {
        _teacherRepository = teacherRepository;
        _teacherDomainService = teacherDomainService;
        _localFileService = localFileService;

    }
    public async Task<OperationResult> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
    {
        var cvFileName = await _localFileService.SaveFileAndGenerateName(request.CvFile, CoreModuleDirectories.CvFileNames);

        var teacher =
            new Domain.TeacherAgg.Models.Teacher(request.UserId, request.UserName, cvFileName,
                _teacherDomainService);
        await _teacherRepository.AddAsync(teacher);
        await _teacherRepository.Save();
        return OperationResult.Success();
    }
}