namespace SocialMedia.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _context;

        public UserRepository(SocialMediaContext context)
        {
            this._context = context;
        }

        public async Task<BaseGenericResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return new BaseGenericResult<IEnumerable<User>>
            {
                Data = users,
                Message = "Loading Data Successfully",
                Status = true,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public async Task<BaseGenericResult<User>> GetUser(int id)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return new BaseGenericResult<User>
            {
                Data = User,
                Message = "Loading Data Successfully",
                Status = true,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
