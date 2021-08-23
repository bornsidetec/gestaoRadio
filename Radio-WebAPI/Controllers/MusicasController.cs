using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radio_WebApi.Data;
using Radio_WebAPI.Models;

namespace Radio_WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MusicasController : ControllerBase
    {
        private readonly IRepository _repo;

        public MusicasController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllMusicasAsync(true);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{musicaId}")]
        public async Task<IActionResult> GetByMusicasId(int musicaId)
        {
            try
            {
                var result = await _repo.GetMusicasAsyncById(musicaId, true);

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
                var result = await _repo.GetMusicasAsyncByInterpreteId(interpreteId, false);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> post(Musicas model)
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

        [HttpPut("{musicaId}")]
        public async Task<IActionResult> put(int musicaId, Musicas model)
        {
            try
            {
                var musica = await _repo.GetMusicasAsyncById(musicaId, false);

                if (musica == null) return NotFound();

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


        [HttpDelete("{musicaId}")]
        public async Task<IActionResult> delete(int musicaId)
        {
            try
            {
                var musica = await _repo.GetMusicasAsyncById(musicaId, false);

                if (musica == null) return NotFound();

                _repo.Delete(musica);

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