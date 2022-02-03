using albumes.application.DTO;
using albumes.application.Handlers.Artists;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace albumes.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly ILogger<AlbumesController> _logger;
        private readonly IArtistsHandler _handler;
        public ArtistsController(ILogger<AlbumesController> logger, IArtistsHandler handler)
        {
            this._logger = logger;
            this._handler = handler;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<ArtistDTO[]>> Get()
        {
            var artists = await Task.Run(() => this._handler.GetArtists());

            return Ok(artists);
        }

        // GET: api/Artists/5
        [HttpGet("{ArtistID}")]
        public async Task<ActionResult<ArtistDTO>> Get(int ArtistID)
        {
            if (ArtistID <= 0)
                return BadRequest("Invalid ID");

            var artist = await Task.Run(() => this._handler.GetArtist(ArtistID));

            if (artist == null)
                return NotFound();

            return Ok(artist);
        }

        // POST: api/Artists
        [HttpPost]
        public async Task<ActionResult<ArtistDTO>> Post([FromBody] ArtistDTO artist)
        {
            if (artist == null)
                return BadRequest("Error when trying to create the album");

            await this._handler.CreateArtistAsync(artist);

            //return StatusCode((int)HttpStatusCode.Created, album);
            return CreatedAtAction(nameof(Get), new { Id = artist.ArtistID }, artist);
        }

        // PUT: api/Artists        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ArtistDTO artist)
        {
            if (artist == null)
                return BadRequest();

            await this._handler.UpdateArtistAsync(artist);

            return NoContent();
        }

        // DELETE: api/Artists/5
        [HttpDelete("{ArtistID}")]
        public async Task<IActionResult> Delete(int ArtistID)
        {
            if (ArtistID <= 0)
                return BadRequest("Invalid ID");

            var album = this._handler.GetArtist(ArtistID).Result;

            if (album == null)
                return NotFound();

            await this._handler.DeleteArtistAsync(album);

            return NoContent();
        }
    }
}
