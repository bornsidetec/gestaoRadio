using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Radio_WebAPI.Models;

namespace Radio_WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        { 
            
        }        
        public DbSet<Musicas> Musicas { get; set; }
        public DbSet<Interpretes> Interpretes { get; set; }
        public DbSet<Albuns> Albuns { get; set; }
        public DbSet<MusicasInterpretes> MusicasInterpretes { get; set; }
        public DbSet<AlbunsInterpretes> AlbunsInterpretes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MusicasInterpretes>()
                .HasKey(MI => new { MI.MusicasId, MI.InterpretesId });

            builder.Entity<AlbunsInterpretes>()
                .HasKey(AI => new { AI.AlbunsId, AI.InterpretesId });

            builder.Entity<Musicas>()
                .HasData(new List<Musicas>(){
                    new Musicas(1, "Aquarela", 1983, 1, 4.2),
                    new Musicas(2, "Garota de Ipanema", 1963, 1, 5.35),
                    new Musicas(3, "Esse cara sou eu", 2021, 2, 4.53),
                    new Musicas(4, "Detalhes", 1973, 2, 5.6),
                });
            
            builder.Entity<Interpretes>()
                .HasData(new List<Interpretes>{
                    new Interpretes(1, "Roberto Carlos"),
                    new Interpretes(2, "Toquinho"),
                    new Interpretes(3, "Vinícius de Morais"),
                });
            
            builder.Entity<Albuns>()
                .HasData(new List<Albuns>(){
                    new Albuns(1, "Classicos", 1990, "https://www.vagalume.com.br/roberto-carlos/discografia/30-grandes-sucessos.webp"),
                    new Albuns(2, "MPB", 1978, "https://www.vagalume.com.br/1470154983100588/default"),
                });

            builder.Entity<MusicasInterpretes>()
                .HasData(new List<MusicasInterpretes>() {
                    new MusicasInterpretes() {MusicasId = 1, InterpretesId = 2 },
                    new MusicasInterpretes() {MusicasId = 2, InterpretesId = 3 },
                    new MusicasInterpretes() {MusicasId = 3, InterpretesId = 1 },
                    new MusicasInterpretes() {MusicasId = 4, InterpretesId = 1 },
               });

            builder.Entity<AlbunsInterpretes>()
                .HasData(new List<AlbunsInterpretes>() {
                    new AlbunsInterpretes() {AlbunsId = 1, InterpretesId = 1 },
                    new AlbunsInterpretes() {AlbunsId = 2, InterpretesId = 2 },
                    new AlbunsInterpretes() {AlbunsId = 2, InterpretesId = 3 },
               });

        }
    }
}