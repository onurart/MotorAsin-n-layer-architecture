using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.ProductsCampaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IProductsCampaignsService:IBaseService<ProductsCampaigns>
    {
        Task<IDataResult<IList<ProductsCampaigns>>> GetList(ProductsCampaignsListPramertDto parameter);
        Task<IDataResult<string>> GetCode(ProductsCampaignsCodeParameterDto parameter);
    }
}
