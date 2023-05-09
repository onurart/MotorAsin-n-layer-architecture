using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Entities.Dtos.Product;
using MotorAsinBasketRobot.Entities.Dtos.ProductCampaign;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IProductCampaignService:IBaseService<ProductCampaign>
    {
        Task<IDataResult<IList<ProductCampaign>>> GetList(ProductCampaignListPramertDto parameter);
    }
}
