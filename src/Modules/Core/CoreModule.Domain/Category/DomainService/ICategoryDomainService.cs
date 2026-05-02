namespace CoreModule.Domain.Category.DomainService
{
    public interface ICategoryDomainService
    {
        bool SlugIsExist(string slug);
    }
}
