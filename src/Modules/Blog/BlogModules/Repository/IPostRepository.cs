using BlogModules.Context;
using BlogModules.Domain;
using Common.Domain.Repository;
using Common.Infrastructure.Repository;

namespace BlogModules.Repository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        void Delete(Post post);
    }
    class PostRepository : BaseRepository<Post, BlogContext>, IPostRepository
    {

        public PostRepository(BlogContext context) : base(context)
        {

        }
        public void Delete(Post post)
        {
            Context.Posts.Remove(post);
        }
    }
}
