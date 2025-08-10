namespace TrainReservationApi.entities
{
    public class Rezervasyon
    {
        public int Id { get; set; } 
        public required string TrenAdi { get; set; }
        public required string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
        public DateTime Tarih { get; set; }
    }
}