using Common.Domain.Repository;
using CoreModule.Domain.TeacherAgg.Models;

namespace CoreModule.Domain.TeacherAgg.Repository
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        void Delete(Models.Teacher teacher);
    }
}
