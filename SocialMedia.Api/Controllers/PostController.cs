
namespace SocialMedia.Api.Controllers
{
    #region Fields

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        #endregion

        #region Get Posts

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var Posts = await _postRepository.GetPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(Posts.Data);
            return StatusCode(200, postDto);
        }

        #endregion

        #region Get Post (id:int)

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post.Data);
            return Ok(postDto);
        }

        #endregion

        #region Save (Edit & Create ) Post
        [HttpPost]
        public async Task<IActionResult> Save(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.SavePost(post);
            return Ok(postDto);
        }
        #endregion

        #region Insert Post

        //[HttpPost]
        //public async Task<IActionResult> Post(PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    await _postRepository.InsertPost(post);
        //    return Ok(postDto);
        //}

        #endregion

        #region Edit Post

        //[HttpPut]
        //public async Task<IActionResult> Put(int id , PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    post.Id = id;

        //    await _postRepository.EditPost(post);
        //    return Ok(postDto);
        //}

        #endregion

        #region Delete Post

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postRepository.DeletePost(id);
            return Ok(result);
        }

        #endregion

    }
}
