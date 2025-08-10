namespace TrainReservationApi.entities
{
    public class Vagon
    {
        public int Id { get; set; } 
        public required string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
        public int TrenId { get; set; }
        public Tren Tren { get; set; }
    }
}
