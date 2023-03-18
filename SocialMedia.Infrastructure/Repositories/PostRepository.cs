namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
    
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context) : base(context) { }


        public async Task<IEnumerable<Post>> GetPostsbyUser(int userid)
        {
            return await _context.Set<Post>().Where(x => x.UserId == userid).ToListAsync();
        }
    }
}
