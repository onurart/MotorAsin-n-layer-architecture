using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IProductService:IBaseService<Product>
    {
        Task<IDataResult<PagedResult<Product>>> GetPagedList(ProductListPramertDto parameter);
        Task<IDataResult<IList<Product>>> GetList(ProductListPramertDto parameter);
        Task<IDataResult<string>> GetCode(ProductCodeParameterDto parameter);
    }
}
