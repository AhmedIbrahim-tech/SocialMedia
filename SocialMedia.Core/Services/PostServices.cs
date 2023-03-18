using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Services;


public class PostServices : IPostServices
{
    private readonly IUnitOfWork _unitOfWork;

    public PostServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public PagedList<Post> GetPosts(PostQueryFilter filters)
    {

        var posts = _unitOfWork.PostRepository.GetAll();

        filters.PageNumber = filters.PageNumber == 0 ? 1 : filters.PageNumber;
        filters.PageSize = filters.PageSize == 0 ? 10 : filters.PageSize;

        if (filters.UserId != null)
        {
            posts = posts.Where(x => x.UserId == filters.UserId);
        }
        if (filters.Date != null)
        {
            posts = posts.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
        }
        if (filters.Description != null)
        {
            posts = posts.Where(x => x.Description.ToLower() == filters.Description.ToLower());
        }

        var pagedPosts = PagedList<Post>.Create(posts, filters.PageNumber, filters.PageSize);

        return pagedPosts;
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
        await _unitOfWork.PostRepository.Edit(dto);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> InsertPost(Post dto)
    {
        var currentUser = await _unitOfWork.UserRepository.GetById(dto.UserId);
        if (currentUser == null) throw new BusinessExceptions("User doesn't exist");
        if (dto.Description.Contains("sex")) { throw new BusinessExceptions("This's Content not allowed"); }

        var userPost = await _unitOfWork.PostRepository.GetPostsbyUser(dto.UserId);
        if (userPost.Count() < 10)
        {
            var lastPost = userPost.OrderByDescending(x => x.Date).FirstOrDefault();
            if ((DateTime.Now - lastPost.Date).TotalDays < 7)
            {
                throw new BusinessExceptions("You are not able to Publish the Post");
            }
        }
        await _unitOfWork.PostRepository.Add(dto);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }


    public async Task<bool> DeletePost(int id)
    {
        await _unitOfWork.PostRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

}
