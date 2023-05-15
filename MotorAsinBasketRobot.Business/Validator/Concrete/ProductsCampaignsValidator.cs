using MotorAsinBasketRobot.Business.Concrete;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Validator.Concrete
{
    public class ProductsCampaignsValidator: IProductsCampaignsValidator
    {
        private readonly IProductsCampaignsDal _productsCampaignsDal;
        private readonly ISpeCodeDal _speCodeDal;
public ProductsCampaignsValidator(IProductsCampaignsDal productsCampaignsDal, ISpeCodeDal speCodeDal)
        {
            _productsCampaignsDal = productsCampaignsDal;
            _speCodeDal = speCodeDal;
        }

        public Task CheckCreateAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task CheckDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CheckUpdateAsync(int id, string code, Documents entity)
        {
            throw new NotImplementedException();
        }
    }
}
