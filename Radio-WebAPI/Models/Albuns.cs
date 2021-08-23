using System.Collections.Generic;

namespace Radio_WebAPI.Models
{
    public class Albuns
    {
        public Albuns(int id, string nome, int ano, string imagem)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ano = ano;
            this.Imagem = imagem;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Imagem { get; set; }
        public IEnumerable<AlbunsInterpretes> AlbunsInterpretes { get; set; }
    }

}