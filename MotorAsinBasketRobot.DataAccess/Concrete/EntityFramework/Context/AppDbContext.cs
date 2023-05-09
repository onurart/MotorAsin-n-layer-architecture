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
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConnection"));
            optionsBuilder.UseSqlServer("Data Source=192.168.181.150;Initial Catalog=MotorAssinBasketRobotProject;User ID=onursa;Password=4473634;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        public virtual DbSet<BasketStatus> BasketStatuses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<IncomingOrderRequests> IncomingOrderRequests { get; set; }
        public virtual DbSet<MASqlConnection> MASqlConnections { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCampaign> ProductCampaigns { get; set; }
    }
}
