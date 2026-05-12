using Common.Query;
using CoreModule.Query._Data;
using CoreModule.Query.Category._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Category.GetChildren;

class GetCourseCategoryChildrenQueryHandler : IBaseQueryHandler<GetCourseCategoryChildrenQuery, List<CourseCategoryDto>>
{
    private readonly QueryContext _context;
    /// <summary></summary>
    /// <param name="context"></param>
    public GetCourseCategoryChildrenQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<List<CourseCategoryDto>> Handle(GetCourseCategoryChildrenQuery request, CancellationToken cancellationToken)
    {
        return await _context.CourseCategories
            .Where(r => r.ParentId == request.ParentId)
            .OrderByDescending(d => d.CreationDate)
            .Select(s => new CourseCategoryDto
            {
                Id = s.Id,
                CreationDate = s.CreationDate,
                Title = s.Title,
                Slug = s.Slug,
                ParentId = s.ParentId
            }).ToListAsync(cancellationToken);
    }
}