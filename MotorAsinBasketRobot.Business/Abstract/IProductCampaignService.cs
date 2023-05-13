using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.ProductCampaign;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IProductCampaignService:IBaseService<ProductCampaign>
    {
        Task<IDataResult<IList<ProductCampaign>>> GetList(ProductCampaignListPramertDto parameter);
        Task<IDataResult<string>> GetCode(ProductCampaignCodeParameterDto parameter);
    }
}
