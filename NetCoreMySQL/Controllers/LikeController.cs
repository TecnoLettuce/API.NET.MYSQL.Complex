using Microsoft.AspNetCore.Mvc;
using NetCoreApiMySQL.Data.Repositories.Interfaces;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;

        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLikes() {
            return Ok(await _likeRepository.GetAllLikesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLikeDetails(int id) {
            return Ok(await _likeRepository.GetLikeDetailsAsync(id));
        }

        [HttpGet]
        [Route("likeduser/{userId}")]

        public async Task<IActionResult> GetLikesByUserId(int userId)
        {
            return Ok(await _likeRepository.GetLikesByUserIdAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLike([FromBody] Like like) {

            if (like == null)
                return BadRequest();

            if (!ModelState.IsValid) 
                return BadRequest();

            await _likeRepository.InsertLikeAsync(like);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLike([FromBody] Like like) {
            if (like == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            await _likeRepository.UpdateLikeAsync(like);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id) {

            await _likeRepository.DeleteLikeAsync(new Like { IdLike = id });

            return NoContent();
        }



    }
}
