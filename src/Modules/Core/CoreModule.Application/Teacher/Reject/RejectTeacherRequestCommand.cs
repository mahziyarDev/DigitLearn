using Common.Application;
using CoreModule.Domain.TeacherAgg.Repository;

namespace CoreModule.Application.Teacher.Reject;

public record RejectTeacherRequestCommand
    (
        Guid TeacherId,
        string Description
        ) : IBaseCommand;
        
        public class RejectTeacherRequestCommandHandler :  IBaseCommandHandler<RejectTeacherRequestCommand>
        {
            private readonly ITeacherRepository _teacherRepository;

            public RejectTeacherRequestCommandHandler(ITeacherRepository teacherRepository)
            { 
                _teacherRepository = teacherRepository;
            }

            public async Task<OperationResult> Handle(RejectTeacherRequestCommand request, CancellationToken cancellationToken)
            {
                var teacher = await _teacherRepository.GetTracking(request.TeacherId);
                if (teacher == null)
                {
                    return OperationResult.NotFound("teacher not found");
                }
                
                _teacherRepository.Delete(teacher);
                //TODO:SEND EVENT
                await _teacherRepository.Save();
                return OperationResult.Success();
            }
        }