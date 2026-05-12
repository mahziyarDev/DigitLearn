using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using CoreModule.Application._Utilities;
using CoreModule.Domain.CourseAgg.DomainService;
using CoreModule.Domain.CourseAgg.Repository;

namespace CoreModule.Application.Course.Create;

public class CreateCourseCommandHandler : IBaseCommandHandler<CreateCourseCommand>
{
    // private readonly IFtpFileService _ftpFileService;
    private readonly ILocalFileService _localFileService;
    private readonly ICourseRepository _repository;
    private readonly ICourseDomainService _domainService;
    /// <summary></summary>
    /// <param name="localFileService"></param>
    /// <param name="domainService"></param>
    /// <param name="repository"></param>
    public CreateCourseCommandHandler(ILocalFileService localFileService, ICourseDomainService domainService, ICourseRepository repository)
    {
        _localFileService = localFileService;
        _domainService = domainService;
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        if (request.ImageFile.IsImage())
        {
            return OperationResult.Error("image not valid");
        }

        var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, CoreModuleDirectories.CourseImage);


        string? videoPath = null;
        Guid courseId = Guid.NewGuid();
        if (request.VideoFile != null)
        {
            if (request.VideoFile.IsValidMp4File() == false)
            {
                return OperationResult.Error("فایل وارد شده نامعتبر است");
            }
            
            //درصورتی که FtpServer برای ذخیره داشتیم از این خط کد استفاده میکنیم
            //videoPath = await _ftpFileService.SaveFileAndGenerateName(request.VideoFile, CoreModuleDirectories.CourseDemo(courseId));
            
            videoPath = await _localFileService.SaveFileAndGenerateName(request.VideoFile, CoreModuleDirectories.CourseDemo(courseId));
        }


        var course = new Domain.CourseAgg.Models.Course(request.TeacherId, request.Title, request.Description, 
            imageName, videoPath??"", request.SeoData, request.Price,
            request.CourseLevel, request.Slug, request.CategoryId,
            request.SubCategoryId, _domainService)
        {
            Id = courseId
        };

        await _repository.AddAsync(course);
        await _repository.Save();
        return OperationResult.Success();
    }
}