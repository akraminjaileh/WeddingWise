using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Models.Entities;
using WeddingWise_Core.Models.EntityConfig;
namespace WeddingWise_Core.Context
{
    public class WeddingWiseDbContext : DbContext
    {
        public WeddingWiseDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AgentTransactionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CarRentalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationCarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationWeddingHallEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WeddingHallEntityTypeConfiguration());
        }

        public DbSet<AgentTransaction> AgentTransactions { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationCar> ReservationCars { get; set; }
        public DbSet<ReservationWeddingHall> ReservationWeddingHalls { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WeddingHall> WeddingHalls { get; set; }

    }
}
