using Common.Infrastructure.Repository;
using CoreModule.Domain.CourseAgg.Repository;

namespace CoreModule.Infrastructure.Persistent.Course;

public class CourseRepository:BaseRepository<Domain.CourseAgg.Models.Course,CoreModuleEfContext> , ICourseRepository
{
    /// <summary></summary>
    /// <param name="context"></param>
    public CourseRepository(CoreModuleEfContext context) : base(context)
    {
    }
}