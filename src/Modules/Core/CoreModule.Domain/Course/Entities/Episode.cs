using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;

namespace CoreModule.Domain.Course.Entities
{
    public class Episode : BaseEntity
    {
        public Episode(string title, Guid token, TimeSpan time, string videoName, string? attachmentName, bool isActive, string englishTitle, Guid sectionId)
        {
            Title = title;
            Token = token;
            Time = time;
            VideoName = videoName;
            AttachmentName = attachmentName;
            IsActive = isActive;
            SectionId = sectionId;
            EnglishTitle = englishTitle;
        }
        public Guid SectionId { get; private set; }
        public string Title { get; private set; }
        public string EnglishTitle { get; private set; }
        public Guid Token { get; private set; }
        public TimeSpan Time { get; private set; }
        public string VideoName { get; private set; }
        public string? AttachmentName { get; private set; }
        public bool IsActive { get; private set; }

        void Guard() 
        {
            NullOrEmptyDomainDataException.CheckString(EnglishTitle, nameof(EnglishTitle));
            NullOrEmptyDomainDataException.CheckString(VideoName, nameof(VideoName));
            NullOrEmptyDomainDataException.CheckString(Title, nameof(Title));
            if (EnglishTitle.IsUniCode())
            {
                throw new InvalidDomainDataException("invalid english title");
            }
        }
    }
}
