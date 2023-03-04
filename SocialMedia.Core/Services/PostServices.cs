namespace SocialMedia.Core.Services
{

    public class PostServices : IPostServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.PostRepository.GetAll();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        //public async Task<int> SavePost(Post dto)
        //{
        //    var result = dto.Id != 0 ? await EditPost(dto) : await InsertPost(dto);
        //    return result;
        //}

        public async Task<bool> EditPost(Post dto)
        {
            _unitOfWork.PostRepository.Edit(dto);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }

        public async Task InsertPost(Post post)
        {
            var currentUser = await _unitOfWork.UserRepository.GetById(post.UserId);
            var userPost = await _unitOfWork.PostRepository.GetPostsbyUser(post.UserId);
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x=>x.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessExceptions("You are not able to Publish the Post");
                }
            }
            if(currentUser == null) { throw new BusinessExceptions("This's User Doesn't Exit"); }
            if(post.Description.Contains("sex")) { throw new BusinessExceptions("This's Content not allowed"); }
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangeAsync();
        }


        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }


    }
}
