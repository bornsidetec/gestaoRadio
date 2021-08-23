using System.Collections.Generic;

namespace Radio_WebAPI.Models
{
    public class Interpretes
    {
        public Interpretes(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<MusicasInterpretes> MusicasInterpretes { get; set; } 
        public IEnumerable<AlbunsInterpretes> AlbunsInterpretes { get; set; } 
    }        
    
}