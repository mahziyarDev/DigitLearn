using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using CoreModule.Application._Utilities;
using CoreModule.Domain.CourseAgg.DomainService;
using CoreModule.Domain.CourseAgg.Repository;

namespace CoreModule.Application.Course.Edit;

public class EditCourseCommandHandler : IBaseCommandHandler<EditCourseCommand>
{
    private readonly ILocalFileService _localFileService;
    private readonly ICourseRepository _repository;
    private readonly ICourseDomainService _domainService;
    /// <summary></summary>
    /// <param name="localFileService"></param>
    /// <param name="domainService"></param>
    /// <param name="repository"></param>
    public EditCourseCommandHandler(ILocalFileService localFileService, ICourseDomainService domainService, ICourseRepository repository)
    {
        _localFileService = localFileService;
        _domainService = domainService;
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetTracking(request.CourseId);
        if (course == null)
        {
            return OperationResult.NotFound("course not found");
        }
        var newImageName = course.ImageName;
        string? newVideoPath = course.VideoName;

        var oldVideoFileName = course.VideoName;
        var oldImageNameFileName = course.ImageName;
        if (request.VideoFile != null)
        {
            if (!request.VideoFile.IsValidMp4File())
            {
                return OperationResult.Error("فایل وارد شده نامعتبر است");
            }

            newVideoPath = await _localFileService.SaveFileAndGenerateName(request.VideoFile, CoreModuleDirectories.CourseDemo(course.Id));
        }

        if (request.ImageFile.IsImage())
        {
            newImageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile!, CoreModuleDirectories.CourseImage);
        }


        course.Edit(request.Title, request.Description, newImageName, newVideoPath,
            request.Price,
            request.SeoData, request.CourseLevel, request.CourseStatus, request.CategoryId, request.SubCategoryId,
            request.Slug,
            _domainService);
            
        _repository.Update(course);
        await _repository.Save();

        DeleteOldFiles(oldImageNameFileName, oldVideoFileName,
            request.VideoFile != null,
            request.ImageFile != null, course);
        return OperationResult.Success();

    }

    /// <summary>
    /// زمانی که از ftp Server  استفاده میکنیم 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="video"></param>
    /// <param name="isUploadNewVideo"></param>
    /// <param name="isUploadNewImage"></param>
    /// <param name="course"></param>
    void DeleteOldFiles(string image, string? video, bool isUploadNewVideo, bool isUploadNewImage, Domain.CourseAgg.Models.Course course)
    {
        if (isUploadNewVideo && string.IsNullOrWhiteSpace(video) == false)
        {
            _localFileService.DeleteFile(CoreModuleDirectories.CourseDemo(course.Id), video);
        }

        if (isUploadNewImage)
        {
            _localFileService.DeleteFile(CoreModuleDirectories.CourseImage, image);
        }
    }
}