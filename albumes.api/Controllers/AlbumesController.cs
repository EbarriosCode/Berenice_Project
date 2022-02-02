using albumes.application.DTO;
using albumes.application.Handlers.Albumes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace albumes.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumesController : ControllerBase
    {
        private readonly ILogger<AlbumesController> _logger;
        private readonly IAlbumesHandler _handler;
        public AlbumesController(ILogger<AlbumesController> logger, IAlbumesHandler handler)
        {
            this._logger = logger;
            this._handler = handler;
        }

        // GET: api/Albumes
        [HttpGet]
        public async Task<ActionResult<AlbumDTO[]>> Get()
        {
            var albumes = await Task.Run(() => this._handler.GetAlbumes());
            
            return Ok(albumes);
        }

        // GET: api/Albumes/5
        [HttpGet("{AlbumID}")]
        public async Task<ActionResult<AlbumDTO>> Get(int AlbumID)
        {
            if (AlbumID <= 0)
                return BadRequest("Invalid ID");

            var album = await Task.Run(() => this._handler.GetAlbum(AlbumID));

            if (album == null)
                return NotFound();

            return Ok(album);
        }

        // POST: api/Albumes
        [HttpPost]
        public async Task<ActionResult<AlbumDTO>> Post([FromBody] AlbumDTO album)
        {
            if (album == null)
                return BadRequest("Error when trying to create the album");

            await this._handler.CreateAlbumAsync(album);

            //return StatusCode((int)HttpStatusCode.Created, album);
            return CreatedAtAction(nameof(Get), new { Id = album.AlbumID}, album);
        }

        // PUT: api/Albumes       
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AlbumDTO album)
        {
            if (album == null)
                return BadRequest();

            await this._handler.UpdateAlbumAsync(album);

            return NoContent();
        }

        // DELETE: api/Albumes/5
        [HttpDelete("{AlbumID}")]
        public async Task<IActionResult> Delete(int AlbumID)
        {
            if (AlbumID <= 0)
                return BadRequest("Invalid ID");

            var album = this._handler.GetAlbum(AlbumID).Result;

            if (album == null)
                return NotFound();

            await this._handler.DeleteAlbumAsync(album);

            return NoContent();
        }
    }
}
