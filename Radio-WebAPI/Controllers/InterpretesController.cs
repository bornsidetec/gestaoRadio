using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radio_WebApi.Data;
using Radio_WebAPI.Models;

namespace Radio_WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InterpretesController : ControllerBase
    {
        private readonly IRepository _repo;

        public InterpretesController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllInterpretesAsync(false, false);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{interpreteId}")]
        public async Task<IActionResult> GetByInterpretesId(int interpreteId)
        {
            try
            {
                var result = await _repo.GetInterpretesAsyncById(interpreteId, true, true);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByMusica/{musicaId}")]
        public async Task<IActionResult> GetByMusicasId(int musicaId)
        {
            try
            {
                var result = await _repo.GetInterpretesAsyncByMusicaId(musicaId, false);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByAlbum/{albumId}")]
        public async Task<IActionResult> GetByAlbunsId(int albumId)
        {
            try
            {
                var result = await _repo.GetInterpretesAsyncByAlbumId(albumId, false);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }        

        [HttpPost]
        public async Task<IActionResult> post(Interpretes model)
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

        [HttpPut("{interpreteId}")]
        public async Task<IActionResult> put(int interpreteId, Interpretes model)
        {
            try
            {
                var interprete = await _repo.GetAlbunsAsyncById(interpreteId, false);

                if (interprete == null) return NotFound();

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


        [HttpDelete("{interpreteId}")]
        public async Task<IActionResult> delete(int interpreteId)
        {
            try
            {
                var interprete = await _repo.GetInterpretesAsyncById(interpreteId, false, false);

                if (interprete == null) return NotFound();

                _repo.Delete(interprete);

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