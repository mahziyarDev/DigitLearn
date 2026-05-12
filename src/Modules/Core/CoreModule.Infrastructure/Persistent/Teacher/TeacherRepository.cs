using Common.Infrastructure.Repository;
using CoreModule.Domain.TeacherAgg.Repository;

namespace CoreModule.Infrastructure.Persistent.Teacher;

internal class TeacherRepository : BaseRepository<Domain.TeacherAgg.Models.Teacher,CoreModuleEfContext>,ITeacherRepository
{
    /// <summary></summary>
    /// <param name="context"></param>
    public TeacherRepository(CoreModuleEfContext context) : base(context)
    {
    }

    public void Delete(Domain.TeacherAgg.Models.Teacher teacher)
    {
        Context.Remove(teacher);
    }
}