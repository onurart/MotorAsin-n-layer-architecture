using Autofac;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Concrete;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework;
namespace MotorAsinBasketRobot.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            
            builder.RegisterType<BasketStatusManager>().As<IBasketStatusService>();
            builder.RegisterType<EfBasketStatusDal>().As<IBasketStatusDal>();
            
            
            builder.RegisterType<SpeCodeManager>().As<ISpeCodeService>();
            builder.RegisterType<EfSpeCodeDal>().As<ISpeCodeDal>();
            base.Load(builder);
        }
    }
}

