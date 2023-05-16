using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.ProductsCampaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class ProductsCampaignsManager : IProductsCampaignsService
    {
        private readonly IProductsCampaignsDal _productsCampaignsService;
        private readonly IProductsCampaignsValidator _productsCampaignsValidator;
        public ProductsCampaignsManager(IProductsCampaignsDal productsCampaignsService, ISpeCodeDal speCodeDal)
        {
            _productsCampaignsService = productsCampaignsService;
            _productsCampaignsValidator = new ProductsCampaignsValidator(_productsCampaignsService, speCodeDal);

        }

        public async Task<IDataResult<ProductsCampaigns>> Create(ProductsCampaigns entity)
        {
            try
            {
                return new SuccessDataResult<ProductsCampaigns>(await _productsCampaignsService.CreateAsync(entity), Messages.ProductsCampaignsget);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductsCampaigns>(ex.Message);
            }
        }

        public async Task<IDataResult<ProductsCampaigns>> Delete(ProductsCampaigns entity)
        {
            try
            {
                return new SuccessDataResult<ProductsCampaigns>(await _productsCampaignsService.DeleteAsync(entity), Messages.ProductsCampaignsdeleted);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductsCampaigns>(ex.Message);
            }
        }

        public async Task<IDataResult<ProductsCampaigns>> Get(int id)
        {
            try
            {
                return new SuccessDataResult<ProductsCampaigns>(await _productsCampaignsService.GetAsync(id, b => b.Id == id, b => b.Id), Messages.ProductsCampaignsget);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductsCampaigns>(ex.Message);
            }
        }

        public async Task<IDataResult<string>> GetCode(ProductsCampaignsCodeParameterDto parameter)
        {
            try
            {
                return new SuccessDataResult<string>(await _productsCampaignsService.GetCodeAsync(x => x.ProductCode, b => b.IsActive == parameter.Statu), Messages.ProductsCampaignsget);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>("",ex.Message);
            }
        }

        public async Task<IDataResult<IList<ProductsCampaigns>>> GetList(ProductsCampaignsListPramertDto parameter)
        {
            try
            {
                return new SuccessDataResult<IList<ProductsCampaigns>>
                (await _productsCampaignsService.GetListAsync(b => b.IsActive == parameter.IsActive, b => b.Id), Messages.ProductsCampaignsgetall);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<ProductsCampaigns>>(ex.Message);
            }
        }

        public Task<IDataResult<ProductsCampaigns>> Update(ProductsCampaigns entity)
        {
            throw new NotImplementedException();
        }
    }
}
