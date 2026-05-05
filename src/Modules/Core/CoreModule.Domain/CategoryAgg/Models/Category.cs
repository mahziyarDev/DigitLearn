using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using CoreModule.Domain.CategoryAgg.DomainService;

namespace CoreModule.Domain.CategoryAgg.Models
{
    public class Category : AggregateRoot
    {
        public Category(string title, string slug, Guid? parentId, ICategoryDomainService categoryDomainService)
        {
            Guard(title, slug);
            if (categoryDomainService.SlugIsExist(slug))
            {
                throw new InvalidDomainDataException("slug is exist");
            }
            if (categoryDomainService.TitleIsExist(title))
            {
                throw new InvalidDomainDataException("title is exist");
            }

            Title = title;
            Slug = slug;
            ParentId = parentId;
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public Guid? ParentId { get; private set; }

        void Guard(string title, string slug)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if (slug.IsUniCode())
            {
                throw new InvalidDomainDataException("slug invalid");
            }
        }

        public void Edit(string title, string slug,ICategoryDomainService categoryDomainService)
        {
            Guard(title, slug);
            if(slug != Slug)
            {
                if (categoryDomainService.SlugIsExist(slug))
                {
                    throw new InvalidDomainDataException("slug is exist");
                }
            }
            if(title != Title)
            {
                if (categoryDomainService.TitleIsExist(title))
                {
                    throw new InvalidDomainDataException("title is exist");
                }
            }
            Title = title;
            Slug = slug;            
        }
    }
}
