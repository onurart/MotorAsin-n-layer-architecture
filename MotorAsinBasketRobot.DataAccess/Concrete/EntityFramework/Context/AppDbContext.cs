using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Entities.Concrete;
namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context
{
    public class AppDbContext : DbContext
    {
        public static string ConnString = "Data Source=192.168.181.150;Initial Catalog=MotorAsinBasketRobotProject;User ID=onursa;Password=4473634;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //public static string ConnString = "Data Source=192.168.181.150;Initial Catalog=MotorAsinBasketRobotProject;User ID=onursa;Password=4473634;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // public static string ConnString = $"Data Source=.;Initial Catalog=MotorAssinBasketRobotProject;User Id=sa;Password=1905;Trust Server Certificate=true";
        //public static string ConnString = "Data Source=ONURUMUTLUOGLU;Initial Catalog=MotorAssinBasketRobotProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public AppDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnString);
        }
        public virtual DbSet<BasketStatus> BasketStatuses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<IncomingOrderRequests> IncomingOrderRequests { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsCampaigns> ProductCampaigns { get; set; }
    }
}
