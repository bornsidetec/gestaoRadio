namespace Radio_WebAPI.Models
{
    public class AlbunsInterpretes
    {
       public AlbunsInterpretes()
        {

        }
        public AlbunsInterpretes(int albunsId, int interpretesId)
        {
            this.AlbunsId = albunsId;
            this.InterpretesId = interpretesId;

        }
        public int AlbunsId { get; set; }
        public Albuns Albuns { get; set; }
        public int InterpretesId { get; set; }
        public Interpretes Interpretes { get; set; }        
    }
}