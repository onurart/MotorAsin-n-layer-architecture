using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context
{
    public class AppDbContext : DbContext
    {
        public static string ConnString = "Data Source=192.168.181.150;Initial Catalog=MotorAsinBasketRobotProject;User ID=onursa;Password=4473634;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
       // public static string ConnString = $"Data Source=.;Initial Catalog=MotorAssinBasketRobotProject;User Id=sa;Password=1905;Trust Server Certificate=true";

        public AppDbContext()
        {
            
        }

        //public static string ConnString = "Data Source=ONURUMUTLUOGLU;Initial Catalog=MotorAssinBasketRobotProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConnection"));
            optionsBuilder.UseSqlServer(ConnString);
        }

        public virtual DbSet<BasketStatus> BasketStatuses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<IncomingOrderRequests> IncomingOrderRequests { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCampaign> ProductCampaigns { get; set; }
    }
}
