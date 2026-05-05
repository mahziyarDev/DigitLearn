using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using CoreModule.Domain.TeacherAgg.DomainService;
using CoreModule.Domain.TeacherAgg.Enums;

namespace CoreModule.Domain.TeacherAgg.Models
{
    public class Teacher : AggregateRoot
    {
        public Teacher(Guid userId, string userName, string cvFileName,
             ITeacherDomainService teacherDomainService)
        {
            Guard(userName, cvFileName);
            if (teacherDomainService.UserNameIsExist(userName))
            {
                throw new InvalidDomainDataException("username is exist");
            }
            UserId = userId;
            UserName = userName;
            CvFileName = cvFileName;
            TeacherStatus = TeacherStatus.Pending;
        }

        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string CvFileName { get; private set; }
        public TeacherStatus TeacherStatus { get; private set; }

        void Guard(string userName, string cvFileName)
        {
            NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));
            NullOrEmptyDomainDataException.CheckString(CvFileName, nameof(CvFileName));
            if (userName.IsUniCode())
            {
                throw new InvalidDomainDataException("username invalid");
            }
        }
        public void AccessptRequest()
        {
            if (TeacherStatus == TeacherStatus.Pending)
            {
                //TODO:Event
                TeacherStatus = TeacherStatus.Active;
            }
        }
        public void ToggleStatus()
        {
            if (TeacherStatus == TeacherStatus.Active)
            {                
                TeacherStatus = TeacherStatus.InActive;
            }
            else if (TeacherStatus == TeacherStatus.InActive)
            {
                TeacherStatus = TeacherStatus.InActive;
            }
        }
    }

}
