using SocialMedia.Core.DTOS;
using SocialMedia.Core.Interfaces.Services;

namespace SocialMedia.Api.Controllers
{
    #region Fields

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postServices;
        private readonly IMapper _mapper;

        public PostController(IPostServices postServices, IMapper mapper)
        {
            _postServices = postServices;
            _mapper = mapper;
        }

        #endregion

        #region Get Posts

        [HttpGet]
        public IActionResult GetPosts()
        {
            var Posts = _postServices.GetPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(Posts);
            return Ok(postDto);
        }

        #endregion

        #region Get Post (id:int)

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postServices.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        #endregion

        #region Save (Edit & Create ) Post
        //[HttpPost]
        //public async Task<IActionResult> Save(PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    var result = await _postServices.SavePost(post);
        //    return Ok(result);
        //}
        #endregion

        #region Insert Post

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postServices.InsertPost(post);
            return Ok(postDto);
        }

        #endregion

        #region Edit Post

        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            await _postServices.EditPost(post);
            return Ok(postDto);
        }

        #endregion

        #region Delete Post

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postServices.DeletePost(id);
            return Ok(result);
        }

        #endregion

    }
}
