using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Identity;
namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context
{
    public class AdminDbContext: IdentityDbContext<AppUser, AppRole, string>
    {
        public static string ConnString = "Data Source=ONURUMUTLUOGLU;Initial Catalog=MotorAssinBasketRobotProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //public static string ConnString = "Data Source=192.168.181.150;Initial Catalog=AdminDb;User ID=onursa;Password=4473634;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // public static string ConnString = $"Data Source=ONURUMUTLUOGLU;Initial Catalog=MotorAssinBasketRobotProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public AdminDbContext()
        {

        }
        public AdminDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddMaConnectionString();
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<MASqlConnection> MASqlConnection { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
       
    }
}
