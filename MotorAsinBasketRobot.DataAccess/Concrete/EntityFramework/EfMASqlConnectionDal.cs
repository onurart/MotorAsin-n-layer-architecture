using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Core.DataAccess.Concrete.EntityFramework;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using MotorAsinBasketRobot.Entities.Concrete;
namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework
{
    public class EfMASqlConnectionDal : EfEntityRepositoryBase<MASqlConnection, AdminDbContext>, IMASqlConnectionDal
    {
        //Data Source=;Initial Catalog=;User Id=;Password=
        public async Task UpdateConnectionString(MASqlConnection mASqlConnection)
        {
            AppDbContext.ConnString = Format(mASqlConnection);
            using (AppDbContext dbcontext = new AppDbContext())
            {
                //int format = 0;
                //while (dbcontext.Database.CanConnect())
                //{
                //    Format(format, mASqlConnection);
                //    format++;
                //}
                int format = 0;
                try
                {
                    if (!dbcontext.Database.CanConnect())
                    {
                        while (!dbcontext.Database.CanConnect() || format == 2)
                        {
                            dbcontext.Database.OpenConnection();
                            if (dbcontext.Database.CanConnect())
                            {
                                break;
                            }

                            //  break; // Veritabanına başarılı bir şekilde bağlandıysa döngüyü sonlandır
                            Format(format, mASqlConnection);
                            format++;
                        }

                    }

                }
                catch (Exception)
                {
                    // Veritabanına bağlantı hatası oluştuğunda yapılacak işlemler
                }
                finally
                {
                    dbcontext.Database.CloseConnection();
                }
            }
        }
        public string Format(int format, MASqlConnection mASqlConnection)
        {
            switch (format)
            {
                case 0:
                    return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User Id={mASqlConnection.UserName};Password={mASqlConnection.Password};Trust Server Certificate={mASqlConnection.Certificate}";
                case 1:
                    return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User ID={mASqlConnection.UserName};Password={mASqlConnection.Password};Connect Timeout={mASqlConnection.Timeout};Encrypt={mASqlConnection.Encrypt};Trust Server Certificate={mASqlConnection.Certificate};Application Intent={mASqlConnection.ApplicationIntent};Multi Subnet Failover={mASqlConnection.Failover}";
                default:
                    return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User Id={mASqlConnection.UserName};Password={mASqlConnection.Password};Trust Server Certificate={mASqlConnection.Certificate}";
                    // return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User ID={mASqlConnection.UserName};Password={mASqlConnection.Password};Connect Timeout={mASqlConnection.Timeout};Encrypt={mASqlConnection.Encrypt};Trust Server Certificate={mASqlConnection.Certificate};Application Intent={mASqlConnection.ApplicationIntent};Multi Subnet Failover={mASqlConnection.Failover}";
            }
        }
        public string Format(MASqlConnection mASqlConnection)
        {
            switch (mASqlConnection.Format)
            {
                case 0:
                    return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User Id={mASqlConnection.UserName};Password={mASqlConnection.Password};Trust Server Certificate={mASqlConnection.Certificate}";
                case 1:
                    return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User ID={mASqlConnection.UserName};Password={mASqlConnection.Password};Connect Timeout={mASqlConnection.Timeout};Encrypt={mASqlConnection.Encrypt};Trust Server Certificate={mASqlConnection.Certificate};Application Intent={mASqlConnection.ApplicationIntent};Multi Subnet Failover={mASqlConnection.Failover}";
                default:
                    return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User Id={mASqlConnection.UserName};Password={mASqlConnection.Password} ;Trust Server Certificate={mASqlConnection.Certificate}";
                    //return $"Data Source={mASqlConnection.ServerName};Initial Catalog={mASqlConnection.DbName};User ID={mASqlConnection.UserName};Password={mASqlConnection.Password};Connect Timeout={mASqlConnection.Timeout};Encrypt={mASqlConnection.Encrypt};Trust Server Certificate={mASqlConnection.Certificate};Application Intent={mASqlConnection.ApplicationIntent};Multi Subnet Failover={mASqlConnection.Failover}";
            }
        }
    }
}
