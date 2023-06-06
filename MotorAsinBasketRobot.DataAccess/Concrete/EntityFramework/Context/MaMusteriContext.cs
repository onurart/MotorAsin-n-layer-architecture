using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context
{
    public class MaMusteriContext:DbContext
    {
        public static string ConnString = "Data Source=192.168.181.150;Initial Catalog=MaMusteri;User ID=onursa;Password=4473634;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public MaMusteriContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnString);
        }

        public virtual DbSet<BasketStatus> BasketStatuses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsCampaigns> ProductCampaigns { get; set; }
    }
}
