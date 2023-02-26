using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var Posts = await _postRepository.GetPosts();
            return StatusCode(200 , Posts);
        }

        [HttpGet("{int:id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var Post = await _postRepository.GetPost(id);
            return StatusCode(200, Post);
        }
    }
}
