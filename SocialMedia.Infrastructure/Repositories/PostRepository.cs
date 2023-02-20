namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var Posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Date = DateTime.Now,
                UserId = x * 2,
                Description = $"Description {x}",
                Image = $"https://misapis.com/{x}"

            });
            return Posts;
        }
    }
}
