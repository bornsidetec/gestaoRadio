using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radio_WebApi.Data;
using Radio_WebAPI.Models;

namespace Radio_WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlbunsController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlbunsController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAlbunsAsync(true);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{albumId}")]
        public async Task<IActionResult> GetByAlbunsId(int albumId)
        {
            try
            {
                var result = await _repo.GetAlbunsAsyncById(albumId, true);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByInterprete/{interpreteId}")]
        public async Task<IActionResult> GetByInterpretesId(int interpreteId)
        {
            try
            {
                var result = await _repo.GetAlbunsAsyncByInterpreteId(interpreteId, false);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Albuns model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{albumId}")]
        public async Task<IActionResult> put(int albumId, Albuns model)
        {
            try
            {
                var album = await _repo.GetAlbunsAsyncById(albumId, false);

                if (album == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }


        [HttpDelete("{albumId}")]
        public async Task<IActionResult> delete(int albumId)
        {
            try
            {
                var album = await _repo.GetAlbunsAsyncById(albumId, false);

                if (album == null) return NotFound();

                _repo.Delete(album);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(new { message = "Registro Deletado." } );
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }
        
    }
}