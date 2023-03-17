namespace SocialMedia.Core.Services;


public class PostServices : IPostServices
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly IGenericRepository<User> _userRepository;

    public PostServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        return await _unitOfWork.PostRepository.GetAll();
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
        return await _unitOfWork.PostRepository.EditPost(dto);
    }

    public async Task<bool> InsertPost(Post dto)
    {
        var currentUser = await _unitOfWork.UserRepository.GetById(dto.UserId);
        if (currentUser == null) throw new BusinessExceptions("User doesn't exist");
        if (dto.Description.Contains("sex")) { throw new BusinessExceptions("This's Content not allowed"); }

        //var userPost = await _unitOfWork.PostRepository.GetPostsbyUser(post.UserId);
        //if (userPost.Count() < 10)
        //{
        //    var lastPost = userPost.OrderByDescending(x => x.Date).FirstOrDefault();
        //    if ((DateTime.Now - lastPost.Date).TotalDays < 7)
        //    {
        //        throw new BusinessExceptions("You are not able to Publish the Post");
        //    }
        //}
        return await _unitOfWork.PostRepository.InsertPost(dto);
    }


    public async Task<bool> DeletePost(int id)
    {
        return await _unitOfWork.PostRepository.DeletePost(id);
    }


}
