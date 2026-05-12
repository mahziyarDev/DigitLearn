

using CoreModule.Domain.TeacherAgg.DomainService;
using CoreModule.Domain.TeacherAgg.Repository;

namespace CoreModule.Application.Teacher;

public class TeacherDomainService : ITeacherDomainService
{
    private readonly ITeacherRepository _repository;

    public TeacherDomainService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public bool UserNameIsExist(string userName)
    {
        return _repository.Exists(f => f.UserName == userName.ToLower());
    }
}