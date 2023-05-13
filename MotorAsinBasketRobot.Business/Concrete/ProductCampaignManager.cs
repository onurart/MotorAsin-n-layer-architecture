using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.ProductCampaign;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class ProductCampaignManager : IProductCampaignService
    {
        private readonly IProductCampaignDal _productCampaignDal;
        private readonly IProductCampaignValidator _productCampaignValidator;

        public ProductCampaignManager(IProductCampaignDal productCampaignDal,ISpeCodeDal speCodeDal)
        {
            _productCampaignDal = productCampaignDal;
            _productCampaignValidator = new ProductCampaignValidator(_productCampaignDal,speCodeDal);
        }

        public Task<IDataResult<ProductCampaign>> Create(ProductCampaign entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProductCampaign>> Delete(ProductCampaign entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ProductCampaign>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<string>> GetCode(ProductCampaignCodeParameterDto parameter)
        {
            try
            {
                return new SuccessDataResult<string>(await _productCampaignDal.GetCodeAsync(x => x.ProductCode, b => b.IsActive == parameter.Statu), Messages.DocumentGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>("", ex.Message);
            }
        }

        public async Task<IDataResult<IList<ProductCampaign>>> GetList(ProductCampaignListPramertDto parameter)
        {
            try
            {
                return new SuccessDataResult<IList<ProductCampaign>>
                    (await _productCampaignDal.GetListAsync(x => x.IsActive == parameter.IsActive, x => x.Id));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<IDataResult<ProductCampaign>> Update(ProductCampaign entity)
        {
            throw new NotImplementedException();
        }
    }
}
