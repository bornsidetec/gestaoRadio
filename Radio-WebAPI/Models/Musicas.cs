using System.Collections.Generic;

namespace Radio_WebAPI.Models
{
    public class Musicas
    {
        public Musicas(int id, string nome, int ano, int estilo, double tempo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ano = ano;
            this.Estilo = estilo;
            this.Tempo = tempo;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Estilo { get; set; }
        public double Tempo { get; set; }
        public IEnumerable<MusicasInterpretes> MusicasInterpretes { get; set; }        
    }
}