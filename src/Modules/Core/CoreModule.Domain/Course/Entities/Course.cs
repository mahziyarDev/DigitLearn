using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using CoreModule.Domain.Course.Enums;
using System;
using static System.Collections.Specialized.BitVector32;

namespace CoreModule.Domain.Course.Entities
{
    public class Course : BaseEntity
    {
        public Course(Guid teacherId, string title, string description,
            string imageName, string videoName,
            SeoData seoData, int price, CourseLevel courseLevel)
        {
            Guard(title, description, imageName);
            TeacherId = teacherId;
            Title = title;
            Description = description;
            ImageName = imageName;
            VideoName = videoName;
            SeoData = seoData;
            Price = price;
            CourseLevel = courseLevel;
            CourseStatus = CourseStatus.StartSoon;
            LastUpdate = DateTime.Now;
            Sections = [];
        }

        /// <summary>معلم</summary>
        public Guid TeacherId { get; set; }
        /// <summary>عنوان</summary>
        public string Title { get; set; }
        /// <summary>توضیحات</summary>
        public string Description { get; set; }
        /// <summary>تصویر دوره</summary>
        public string ImageName { get; set; }
        /// <summary>ویدیو معرفی</summary>
        public string? VideoName { get; set; }
        public SeoData SeoData { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Price { get; set; }
        public CourseLevel CourseLevel { get; private set; }
        public CourseStatus CourseStatus { get; set; }
        public ICollection<Section> Sections { get; private set; }

        public void AddSection(int displayOrder, string title)
        {
            if(Sections.Any(x=>x.Title == title))
            {
                throw new InvalidDomainDataException("title is Exist");
            }

            Sections.Add(new Section(title, displayOrder, Id));
        }

        public void RemoveSection(Guid sectionId)
        {
            var section = Sections.FirstOrDefault(x => x.Id == sectionId);
            if (section == null) throw new InvalidDomainDataException("section not found");

            Sections.Remove(section);
        }

        public void AddEpisode(Guid sectionId,  string title, Guid token,
            TimeSpan time, string videoExtension, string? attachmentExtension, 
            bool isActive, string englishTitle)
        {
            var section = Sections.FirstOrDefault(x => x.Id == sectionId);
            if (section == null) throw new InvalidDomainDataException("section not found");

            var episodeCount = Sections.Sum(x=>x.Episodes.Count());
            var episodeTitle = $"{episodeCount + 1}-{englishTitle}";

            string attName = null;

            if(string.IsNullOrWhiteSpace(attachmentExtension) == false)
            {
                attName = $"{episodeTitle}.{attachmentExtension}";              
            }

            var videoName = $"{episodeTitle}.{videoExtension}";

            //if (isActive)
            //{
            //    LastUpdate = DateTime.Now;
            //    if (CourseStatus == CourseStatus.StartSoon)
            //    {
            //        CourseStatus = CourseStatus.InProgress;
            //    }
            //}
         

            section.Episodes
                .Add(new Episode(title, token, time, videoName, attName, isActive, englishTitle, sectionId));
        }

        void Guard(string title, string description, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        }

    }
}
