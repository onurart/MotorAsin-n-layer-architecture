using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context
{
    public class AdminDbContext: DbContext
    {
        //public static string ConnString = "Data Source=192.168.181.150;Initial Catalog=AdminDb;User ID=onursa;Password=4473634;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // public static string ConnString = $"Data Source=ONURUMUTLUOGLU;Initial Catalog=MotorAssinBasketRobotProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public static string ConnString = $"Data Source=.;Initial Catalog=MotorAssinBasketRobotProject;User Id=sa;Password=1905;Trust Server Certificate=true";
        //"Data Source=ONURUMUTLUOGLU;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
        //public static string ConnString = "Data Source=ONURUMUTLUOGLU;Initial Catalog=MotorAssinBasketRobotProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public AdminDbContext()
        {

        }
        public AdminDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConnection"));
            optionsBuilder.UseSqlServer(ConnString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddMaConnectionString();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<MASqlConnection> MASqlConnection { get; set; }
       
    }
}
