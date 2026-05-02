using Common.Domain;
using Common.Domain.Exceptions;

namespace CoreModule.Domain.Course.Models
{
    public class Section : BaseEntity
    {
        public Section(string title, int displayOrder, Guid courseId)
        {
            Gaurd(title);
            Title = title;
            DisplayOrder = displayOrder;
            CourseId = courseId;
            Episodes = [];
        }
        public Guid CourseId { get; private set; }

        public string Title { get; private set; }
        public int DisplayOrder { get; private set; }
        public ICollection<Episode> Episodes { get; private set; }

        void Gaurd(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        }

        public void AddEpisode(string title, Guid token, TimeSpan time, string videoName, string? attachmentName, bool isActive, string englishTitle)
        {
            Episodes.Add(new Episode(title, token, time, videoName, attachmentName, isActive, englishTitle, Id));
        }
        public void Edit(string title, int displayOrder)
        {
            Gaurd(title);
            Title = title;
            DisplayOrder = displayOrder;
        }
    }

}

