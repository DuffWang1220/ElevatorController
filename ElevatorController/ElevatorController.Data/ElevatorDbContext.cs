using ElevatorController.DataModel;
using Microsoft.EntityFrameworkCore;
namespace ElevatorController.Data
{
    public class ElevatorDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ElevatorDb");
        }
        public DbSet<DestinationFloor> DestinationFloors { get; set; }
    }
}
