namespace SocialMedia.Core.Services
{

    public class PostServices : IPostServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.Post.GetAll();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.Post.GetById(id);
        }

        public async Task<int> SavePost(Post dto)
        {
            var result = dto.Id != 0 ? await EditPost(dto) : await InsertPost(dto);
            return result;
        }

        public async Task<int> EditPost(Post dto)
        {
            return await _unitOfWork.Post.Edit(dto);
        }

        public async Task<int> InsertPost(Post post)
        {
            var currentUser = await _unitOfWork.User.GetById(post.UserId);
            if(currentUser == null) { throw new Exception("This's User Doesn't Exit"); }
            if(post.Description.Contains("sex")) { throw new Exception("This's Content not allowed"); }
            return await _unitOfWork.Post.Add(post);
        }


        public async Task<int> DeletePost(int id)
        {
            return await _unitOfWork.Post.Delete(id);
        }


    }
}
