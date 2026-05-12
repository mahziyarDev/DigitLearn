using Common.Application;
using Common.Domain.ValueObjects;
using CoreModule.Domain.CourseAgg.Enums;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Course.Create;

public record CreateCourseCommand(
    Guid TeacherId,
    Guid CategoryId,
    Guid SubCategoryId,
    string Title,
    string Slug,
    string Description,
    IFormFile ImageFile,
    IFormFile? VideoFile,
    int Price,
    SeoData SeoData,
    CourseLevel CourseLevel
) : IBaseCommand;