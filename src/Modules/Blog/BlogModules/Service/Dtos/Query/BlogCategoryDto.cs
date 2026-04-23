using Microsoft.Identity.Client;

namespace BlogModules.Service.Dtos.Query;

public class BlogCategoryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}