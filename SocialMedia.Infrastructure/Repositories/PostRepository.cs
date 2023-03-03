
namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            this._context = context;
        }
        public async Task<BaseGenericResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return new BaseGenericResult<IEnumerable<Post>>
            {
                Data = posts,
                Message = "Loading Data Successfully",
                Status = true,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public async Task<BaseGenericResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            return new BaseGenericResult<Post>
            {
                Data = post,
                Message = "Loading Data Successfully",
                Status = true,
                StatusCode = (int)HttpStatusCode.OK
            };
        }




        public async Task<BaseGenericResult<int>> InsertPost(Post dto)
        {
            _context.Posts.Add(dto);
            var result = await _context.SaveChangesAsync();
            return new BaseGenericResult<int>
            {
                Data = result,
                Message = "Created Successfully",
                Status = true,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public async Task<BaseGenericResult<int>> EditPost(Post dto)
        {
            var CurrentPost = await GetPost(dto.Id);
            if (CurrentPost != null)
            {
                CurrentPost.Data.Description = dto.Description;
                CurrentPost.Data.Date = dto.Date;
                CurrentPost.Data.Image = dto.Image;
                var result = await _context.SaveChangesAsync();
                return new BaseGenericResult<int>
                {
                    Data = result,
                    Message = "Created Successfully",
                    Status = true,
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            return new BaseGenericResult<int>
            {
                Data = 0,
                Message = "Failed",
                Status = false,
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        public async Task<BaseGenericResult<bool>> DeletePost(int id)
        {
            var CurrentPost = await GetPost(id);
            if (CurrentPost != null)
            {
                _context.Posts.Remove(CurrentPost.Data);
                await _context.SaveChangesAsync();
                return new BaseGenericResult<bool>
                {
                    Data = true,
                    Message = "Deleted Successfully",
                    Status = true,
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            return new BaseGenericResult<bool>
            {
                Data = false,
                Message = "Failed",
                Status = false,
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
