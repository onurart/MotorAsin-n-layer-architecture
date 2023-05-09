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
    public class ProductCampaignValidator : IProductCampaignValidator
    {
        private readonly IProductCampaignDal _productCampaignDal;
        private readonly ISpeCodeDal _speCodeDal;

        public ProductCampaignValidator(IProductCampaignDal productCampaignDal, ISpeCodeDal speCodeDal)
        {
            _productCampaignDal = productCampaignDal;
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

        public Task CheckUpdateAsync(int id, string code, ProductCampaign entity)
        {
            throw new NotImplementedException();
        }
    }
}
