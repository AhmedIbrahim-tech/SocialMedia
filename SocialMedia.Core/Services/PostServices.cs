namespace SocialMedia.Core.Services
{

    public class PostServices : IPostServices
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostServices(IPostRepository postRepository , IUserRepository userRepository)
        {
            this._postRepository = postRepository;
            this._userRepository = userRepository;
        }

        public async Task<BaseGenericResult<IEnumerable<Post>>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }

        public async Task<BaseGenericResult<Post>> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }

        public async Task<BaseGenericResult<int>> SavePost(Post dto)
        {
            var result = dto.Id != 0 ? await EditPost(dto) : await InsertPost(dto);
            return result;
        }

        public async Task<BaseGenericResult<int>> EditPost(Post dto)
        {
            return await _postRepository.EditPost(dto);
        }

        public async Task<BaseGenericResult<int>> InsertPost(Post post)
        {
            var currentUser = await _userRepository.GetUser(post.UserId);
            if(currentUser == null) { throw new Exception("This's User Doesn't Exit"); }
            if(post.Description.Contains("sex")) { throw new Exception("This's Content not allowed"); }
            return await _postRepository.InsertPost(post);
        }


        public async Task<BaseGenericResult<bool>> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }


    }
}
