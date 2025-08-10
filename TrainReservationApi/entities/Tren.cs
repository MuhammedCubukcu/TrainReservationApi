namespace TrainReservationApi.entities
{
    public class Tren
    {
        public int Id { get; set; } // Primary key
        public required string Ad { get; set; }
        public List<Vagon> Vagonlar { get; set; } = new();  // Tek tanım yeterli
    }
}
