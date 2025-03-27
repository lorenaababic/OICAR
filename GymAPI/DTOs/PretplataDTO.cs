namespace GymAPI.DTOs
{
    public class PretplataDTO
    {
        public int Id { get; set; }

        public int TipPretplateid { get; set; }

        public DateOnly DatumPocetka { get; set; }

        public DateOnly DatumZavrsetka { get; set; }
    }
}
