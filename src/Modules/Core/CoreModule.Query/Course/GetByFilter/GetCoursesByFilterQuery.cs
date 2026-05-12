using Common.Query;
using CoreModule.Query.Course._DTOs;

namespace CoreModule.Query.Course.GetByFilter;

public class GetCoursesByFilterQuery : QueryFilter<CourseFilterResult, CourseFilterParams>
{   
    /// <summary></summary>
    /// <param name="filterParams"></param>
    public GetCoursesByFilterQuery(CourseFilterParams filterParams) : base(filterParams)
    {
    }
}