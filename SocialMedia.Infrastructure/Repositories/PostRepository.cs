namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }
 
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> InsertPost(Post post)
        {
            try
            {
                _context.Posts.AddAsync(post);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> EditPost(Post entity)
        {
            try
            {
                var currentpost = await GetById(entity.Id);

                currentpost.Date = entity.Date;
                currentpost.Description = entity.Description;
                currentpost.Image = entity.Image;

                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
        public async Task<bool> DeletePost(int id)
        {
            var currentpost = await GetById(id);
            _context.Posts.Remove(currentpost);
            var result = await _context.SaveChangesAsync();
            return result > 0;

        }

        public Task<IEnumerable<Post>> GetPostsbyUser(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
