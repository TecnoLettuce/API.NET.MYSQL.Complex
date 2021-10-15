using Microsoft.AspNetCore.Mvc;
using NetCoreApiMySQL.Data.Repositories;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMySQL.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _postRepository.GetAllPostsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostDetails(int id)
        {
            return Ok(await _postRepository.GetPostDetailsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            // Validaciones 
            if (post == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _postRepository.InsertPostAsync(post);

            return Created("Created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] Post post)
        {

            // Validaciones 
            if (post == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _postRepository.UpdatePostAsync(post);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postRepository.DeletePostAsync(new Post() { IdPost = id });

            return NoContent();
        }

    }
}
