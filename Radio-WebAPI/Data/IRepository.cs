using System.Threading.Tasks;
using Radio_WebAPI.Models;

namespace Radio_WebApi.Data
{
    public interface IRepository
    {
        //Genericos
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Musicas
        Task<Musicas[]> GetAllMusicasAsync(bool listaInterpretes);        
        Task<Musicas> GetMusicasAsyncById(int musicaId, bool listaInterpretes);
        Task<Musicas[]> GetMusicasAsyncByInterpreteId(int interpreteId, bool listaInterpretes);
        
        //Interpretes
        Task<Interpretes[]> GetAllInterpretesAsync(bool listaAlbuns, bool listaMusicas);
        Task<Interpretes> GetInterpretesAsyncById(int interpreteId, bool listaAlbuns, bool listaMusicas);
        Task<Interpretes[]> GetInterpretesAsyncByMusicaId(int musicaId, bool listaAlbuns);
        Task<Interpretes[]> GetInterpretesAsyncByAlbumId(int albumId, bool listaMusicas);

        //Albuns
        Task<Albuns[]> GetAllAlbunsAsync(bool listaInterpretes);        
        Task<Albuns> GetAlbunsAsyncById(int albumId, bool listaInterpretes);
        Task<Albuns[]> GetAlbunsAsyncByInterpreteId(int interpreteId, bool listaInterpretes);

    }
}