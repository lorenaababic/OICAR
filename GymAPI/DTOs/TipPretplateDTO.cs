namespace GymAPI.DTOs
{
    public class TipPretplateDTO
    {
        public int Id { get; set; }

        public string Naziv { get; set; } = null!;

        public int Trajanje { get; set; }

        public decimal Cijena { get; set; }
    }
}
