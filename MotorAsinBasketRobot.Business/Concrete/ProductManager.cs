using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Product;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductValidator productValidator;
        public ProductManager(IProductDal productDal, ISpeCodeDal speCodeDal)
        {
            _productDal = productDal;
            productValidator = new ProductValidator(_productDal, speCodeDal);
        }
        public async Task<IDataResult<Product>> Create(Product product)
        {
            try
            {
                await productValidator.CheckCreateAsync(product.Code);
                return new SuccessDataResult<Product>(await _productDal.CreateAsync(product), Messages.ProductAdded);

            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Product>(ex.Message);
            }
        }


        public async Task<IDataResult<Product>> Delete(Product product)
        {
            try
            {
                return new SuccessDataResult<Product>(await _productDal.DeleteAsync(product), Messages.ProductDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Product>(ex.Message);
            }
        }
        public async Task<IDataResult<Product>> Get(int id)
        {
            try
            {
                return new SuccessDataResult<Product>(await _productDal.GetAsync(id, b => b.Id == id, b => b.Code), Messages.ProductGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(ex.Message);
            }
        }




        public async Task<IDataResult<string>> GetCode(ProductCodeParameterDto parameter)
        {
            try
            {
                return new SuccessDataResult<string>(await _productDal.GetCodeAsync(x => x.Code, b => b.IsActive == parameter.Statu), Messages.ProductGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>("", ex.Message);
            }
        }
        public async Task<IDataResult<IList<Product>>> GetList(ProductListPramertDto parameter)
        {
            try
            {
                return new SuccessDataResult<IList<Product>>
                (await _productDal.GetListAsync(b => b.IsActive == parameter.IsActive, b => b.Code), Messages.ProductGetAll);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Product>>(ex.Message);
            }
        }
        public async Task<IDataResult<Product>> Update(Product product)
        {
            try
            {
                await productValidator.CheckUpdateAsync(product.Id, product.Code, product);
                return new SuccessDataResult<Product>(await _productDal.UpdateAsync(product), Messages.ProductUpdated);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(product, ex.Message);
            }
        }
        public Task<IDataResult<PagedResult<Product>>> GetPagedList(ProductListPramertDto parameter)
        {
            throw new NotImplementedException();
        }
    }
}
