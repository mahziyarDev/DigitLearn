using AutoMapper;
using BlogModules.Domain;
using BlogModules.Service.Dtos.Command;
using BlogModules.Service.Dtos.Query;

namespace BlogModules;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category, BlogCategoryDto>().ReverseMap();
        CreateMap<Category, CreateBlogCategoryCommand>().ReverseMap();


        CreateMap<Post, CreatePostCommand>().ReverseMap();
        CreateMap<Post, BlogPostDto>().ReverseMap();
    }
}