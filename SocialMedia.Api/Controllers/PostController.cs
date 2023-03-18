using Newtonsoft.Json;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.QueryFilters;
using System.Net;

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
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPosts([FromQuery] PostQueryFilter filters)
        {
            var posts = _postServices.GetPosts(filters);

            var postdto = _mapper.Map<IEnumerable<PostDTO>>(posts);

            var response = new BaseGenericResult<IEnumerable<PostDTO>>(true, (int)HttpStatusCode.OK, "Data Loading Success", postdto);
            var metadata = new
            {
                posts.TotalCount ,
                posts.PageSize ,
                posts.CurrentPage ,
                posts.TotalPages ,
                posts.HasNextPage ,
                posts.HasPreviousPage ,
                //NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPosts))).ToString(),
                //PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPosts))).ToString()
            };

                Response.Headers.Add("X-Pagination" , JsonConvert.SerializeObject(metadata));
            return StatusCode(response.StatusCode, response);
 
            #region Old Syntax

            //var postdto = Posts.Select(x => new PostDTO
            //{
            //    Id = x.Id,
            //    Date = x.Date,
            //    Description = x.Description,
            //    Image = x.Image,
            //    UserId = x.UserId
            //});

            #endregion

        }

        #endregion

        #region Get Post (id:int)

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postServices.GetPost(id);

            var postdto = _mapper.Map<PostDTO>(post);

            if (postdto != null)
            {
                var response = new BaseGenericResult<PostDTO>(true, (int)HttpStatusCode.OK, "Data Loading Success", postdto);

                return StatusCode(response.StatusCode, response);
            }
            else
            {

                var response = new BaseGenericResult<IEnumerable<PostDTO>>(false, (int)HttpStatusCode.InternalServerError, "Loading Data Filed", null);

                return StatusCode(response.StatusCode, response);
            }


            #region Old Syntax

            //var postdto = new PostDTO
            //{
            //    Id = post.Id,
            //    Date = post.Date,
            //    Description = post.Description,
            //    Image = post.Image,
            //    UserId = post.UserId
            //};

            #endregion

        }

        #endregion

        #region Insert Post

        [HttpPost]
        public async Task<IActionResult> Post(PostDTO postDTO)
        {
            #region Old syntax

            //var post = new Post
            //{
            //    Id = postDTO.Id,
            //    Date = postDTO.Date,
            //    Description = postDTO.Description,
            //    Image = postDTO.Image,
            //    UserId = postDTO.UserId
            //};

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            #endregion

            var post = _mapper.Map<Post>(postDTO);

            var result = await _postServices.InsertPost(post);

            var response = new BaseGenericResult<bool>(true, (int)HttpStatusCode.OK, "Created Successfully", result);

            return StatusCode(response.StatusCode, response);
        }

        #endregion

        #region Edit Post

        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            post.Id = id;

            var result = await _postServices.EditPost(post);

            var response = new BaseGenericResult<bool>(true, (int)HttpStatusCode.OK, "Updated Successfully", result);

            return StatusCode(response.StatusCode, response);
        }

        #endregion

        #region Delete Post

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postServices.DeletePost(id);

            var response = new BaseGenericResult<bool>(true, (int)HttpStatusCode.OK, "Deleted Successfully", result);

            return StatusCode(response.StatusCode, response);
        }

        #endregion
    }
}
