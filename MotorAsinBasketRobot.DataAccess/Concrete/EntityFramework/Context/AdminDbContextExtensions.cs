using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Entities.Concrete;
using System.Data;

namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context
{
    public static class AdminDbContextExtensions
    {
        public static void AddMaConnectionString(this ModelBuilder builder)
        {
            builder.Entity<MASqlConnection>(s =>
            {
                s.ToTable("MASqlConnection");
                s.HasKey(s => s.Id);
                s.Property(s => s.Id).IsRequired().HasColumnType(SqlDbType.Int.ToString());
                s.Property(s => s.EnmConnetion).HasColumnType(SqlDbType.TinyInt.ToString());
                s.Property(s => s.CustomerCode).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.ServerName).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.DbName).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.UserName).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.Password).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.Encrypt).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.Failover).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.Certificate).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.ApplicationIntent).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(250);
                s.Property(s => s.Timeout).HasColumnType(SqlDbType.Float.ToString()).HasMaxLength(250);
                s.Property(s => s.Format).HasColumnType(SqlDbType.TinyInt.ToString()).HasMaxLength(250);
            });
        }
    }
}
