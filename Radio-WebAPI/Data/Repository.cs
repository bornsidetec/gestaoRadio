using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Radio_WebAPI.Models;

namespace Radio_WebApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);            
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Musicas[]> GetAllMusicasAsync(bool listaInterpretes = false)
        {
            IQueryable<Musicas> query = _context.Musicas;

            if (listaInterpretes)
            {
                query = query.Include(mi => mi.MusicasInterpretes)
                             .ThenInclude(i => i.Interpretes);
            }

            query = query.AsNoTracking()
                         .OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Musicas> GetMusicasAsyncById(int musicaId, bool listaInterpretes)
        {
            IQueryable<Musicas> query = _context.Musicas;

            if (listaInterpretes)
            {
                query = query.Include(mi => mi.MusicasInterpretes)
                             .ThenInclude(i => i.Interpretes);
            }

            query = query.AsNoTracking()
                         .OrderBy(musica => musica.Id)
                         .Where(musica => musica.Id == musicaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Musicas[]> GetMusicasAsyncByInterpreteId(int interpreteId, bool listaInterpretes)
        {
            IQueryable<Musicas> query = _context.Musicas;

            if (listaInterpretes)
            {
                query = query.Include(mi => mi.MusicasInterpretes)
                             .ThenInclude(i => i.Interpretes);
            }

            query = query.AsNoTracking()
                         .OrderBy(musica => musica.Id)
                         .Where(musica => musica.MusicasInterpretes.Any(mi => mi.InterpretesId == interpreteId));

            return await query.ToArrayAsync();
        }

        public async Task<Interpretes[]> GetAllInterpretesAsync(bool listaAlbuns, bool listaMusicas)
        {
            IQueryable<Interpretes> query = _context.Interpretes;

            if (listaAlbuns)
            {
                query = query.Include(ai => ai.AlbunsInterpretes)
                             .ThenInclude(a => a.Albuns);
            }

            if (listaMusicas)
            {
                query = query.Include(mi => mi.MusicasInterpretes)
                             .ThenInclude(m => m.Musicas);
            }

            query = query.AsNoTracking()
                         .OrderBy(interprete => interprete.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Interpretes> GetInterpretesAsyncById(int interpreteId, bool listaAlbuns, bool listaMusicas)
        {
            IQueryable<Interpretes> query = _context.Interpretes;

            if (listaAlbuns)
            {
                query = query.Include(ai => ai.AlbunsInterpretes)
                             .ThenInclude(a => a.Albuns);
            }

            if (listaMusicas)
            {
                query = query.Include(mi => mi.MusicasInterpretes)
                             .ThenInclude(m => m.Musicas);
            }

            query = query.AsNoTracking()
                         .OrderBy(interprete => interprete.Id)
                         .Where(interprete => interprete.Id == interpreteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Interpretes[]> GetInterpretesAsyncByMusicaId(int musicaId, bool listaAlbuns)
        {
            IQueryable<Interpretes> query = _context.Interpretes;

            if (listaAlbuns)
            {
                query = query.Include(ai => ai.AlbunsInterpretes)
                             .ThenInclude(a => a.Albuns);
            }

            query = query.AsNoTracking()
                         .OrderBy(interprete => interprete.Id)
                         .Where(interprete => interprete.MusicasInterpretes.Any(mi =>
                            mi.MusicasId == musicaId));

            return await query.ToArrayAsync();
        }

        public async Task<Interpretes[]> GetInterpretesAsyncByAlbumId(int albumId, bool listaMusicas)
        {
            IQueryable<Interpretes> query = _context.Interpretes;

            if (listaMusicas)
            {
                query = query.Include(mi => mi.MusicasInterpretes)
                             .ThenInclude(m => m.Musicas);
            }

            query = query.AsNoTracking()
                         .OrderBy(interprete => interprete.Id)
                         .Where(interprete => interprete.AlbunsInterpretes.Any(ai =>
                            ai.AlbunsId == albumId));

            return await query.ToArrayAsync();
        }  

        public async Task<Albuns[]> GetAllAlbunsAsync(bool listaInterpretes = false)
        {
            IQueryable<Albuns> query = _context.Albuns;

            if (listaInterpretes)
            {
                query = query.Include(ai => ai.AlbunsInterpretes)
                             .ThenInclude(i => i.Interpretes);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Albuns> GetAlbunsAsyncById(int albumId, bool listaInterpretes)
        {
            IQueryable<Albuns> query = _context.Albuns;

            if (listaInterpretes)
            {
                query = query.Include(ai => ai.AlbunsInterpretes)
                             .ThenInclude(i => i.Interpretes)
                             .ThenInclude(i => i.Nome);
            }

            query = query.AsNoTracking()
                         .OrderBy(album => album.Id)
                         .Where(album => album.Id == albumId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Albuns[]> GetAlbunsAsyncByInterpreteId(int interpreteId, bool listaInterpretes)
        {
            IQueryable<Albuns> query = _context.Albuns;

            if (listaInterpretes)
            {
                query = query.Include(ai => ai.AlbunsInterpretes)
                             .ThenInclude(i => i.Interpretes)
                             .ThenInclude(i => i.Nome);
            }

            query = query.AsNoTracking()
                         .OrderBy(album => album.Id)
                         .Where(album => album.AlbunsInterpretes.Any(ai => ai.InterpretesId == interpreteId));

            return await query.ToArrayAsync();
        }







    }

}