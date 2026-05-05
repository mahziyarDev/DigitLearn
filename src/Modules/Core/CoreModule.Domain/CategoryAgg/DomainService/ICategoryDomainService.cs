namespace CoreModule.Domain.CategoryAgg.DomainService
{
    public interface ICategoryDomainService
    {
        bool SlugIsExist(string slug);
        bool TitleIsExist(string slug);
        
    }
}
