using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{

    public class StationsDbContext : DbContext
    {
        public StationsDbContext()
        {
        }

        public StationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<CustomerCard> CustomerCards { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Trip> Trips { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<CustomerCard>(customerCard =>
                {
                    customerCard
                        .Property(cc => cc.Type)
                        .HasDefaultValue(CardType.Normal);
                });

            builder
                .Entity<SeatingClass>(seatingClass =>
                {
                    seatingClass
                        .HasIndex(sc => sc.Abbreviation)
                        .IsUnique(true);

                    seatingClass
                        .HasIndex(sc => sc.Name)
                        .IsUnique(true);

                    seatingClass
                        .Property(sc => sc.Abbreviation)
                        .HasColumnType("CHAR(2)");
                });

            /*builder
                .Entity<Station>(station =>
                {
                    station
                        .HasIndex(s => s.Name)
                        .IsUnique(true);
                });*/
            

            builder
                .Entity<Train>(train =>
                {
                    train
                        .HasIndex(t => t.TrainNumber)
                        .IsUnique(true);
                });

           

            builder
                .Entity<Trip>(trip =>
                {
                    trip
                        .Property(t => t.Status)
                        .HasDefaultValue(TripStatus.OnTime);

                    trip
                        .HasOne(t => t.OriginStation)
                        .WithMany(os => os.TripsFrom)
                        .HasForeignKey(t => t.OriginStationId)
                        .OnDelete(DeleteBehavior.Restrict);

                    trip
                        .HasOne(t => t.DestinationStation)
                        .WithMany(ds => ds.TripsTo)
                        .HasForeignKey(t => t.DestinationStationId)
                        .OnDelete(DeleteBehavior.Restrict);

                    trip
                        .HasOne(t => t.Train)
                        .WithMany(tr => tr.Trips)
                        .HasForeignKey(t => t.TrainId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}