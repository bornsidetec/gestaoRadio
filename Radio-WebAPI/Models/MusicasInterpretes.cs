namespace Radio_WebAPI.Models
{
    public class MusicasInterpretes
    {
       public MusicasInterpretes()
        {

        }
        public MusicasInterpretes(int musicasId, int interpretesId)
        {
            this.MusicasId = musicasId;
            this.InterpretesId = interpretesId;

        }
        public int MusicasId { get; set; }
        public Musicas Musicas { get; set; }
        public int InterpretesId { get; set; }
        public Interpretes Interpretes { get; set; }
        
    }        
    
}