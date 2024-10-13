using Microsoft.AspNetCore.Mvc;
using DAO.Models;
using Services.postsService;
using System.Collections.Generic;
using Services.PostsService;

namespace Forum_Ayoub_abdedaim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _postService;

        public PostController(IPost postService)
        {
            _postService = postService;
        }

        // GET: api/post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _postService.allposts();
        }

        // GET api/post/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _postService.FindById(id);
        }

        // POST api/post
        [HttpPost]
        public int CreatePost([FromBody] Post post)
        {
            return _postService.addPost(post);
        }

        // PUT api/post/5
        [HttpPut("{id}")]
        public Post? UpdatePost(int id, [FromBody] Post post)
        {
            return _postService.updatePost(post, id);
        }

        // DELETE api/post/5
        [HttpDelete("{id}")]
        public Post? DeletePost(int id)
        {
            return _postService.deletePost(id);
        }
    }
}
