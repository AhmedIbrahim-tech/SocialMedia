

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<int> InsertPost(Post dto)
        {
            _context.Posts.Add(dto);
            return await _context.SaveChangesAsync();
        }
    }
}
