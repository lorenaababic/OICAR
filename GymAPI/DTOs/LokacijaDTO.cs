namespace GymAPI.DTOs
{
    public class LokacijaDTO
    {
        public int Id { get; set; }

        public string Ime { get; set; } = null!;

        public string Adresa { get; set; } = null!;

        public int Longitude { get; set; }

        public int Latitude { get; set; }
    }
}
