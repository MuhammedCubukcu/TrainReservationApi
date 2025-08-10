using Microsoft.EntityFrameworkCore;
using TrainReservationApi.entities;

namespace TrainReservationApi.Data
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tren> Trenler { get; set; }
        public DbSet<Vagon> Vagonlar { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        // Diðer entity'ler eklenebilir
    }
}