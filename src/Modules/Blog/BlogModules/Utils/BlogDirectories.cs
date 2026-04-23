
namespace BlogModules.Utils
{
    public static class BlogDirectories
    {
        public  static readonly string PostImage = "wwwroot/blog/images";
        public static string GetPostImage(string imageName)
        {
            return $"{PostImage.Replace("wwwroot", "")}/{imageName}";
        }
    }    
}

