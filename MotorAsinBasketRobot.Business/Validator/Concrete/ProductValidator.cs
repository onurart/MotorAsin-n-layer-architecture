using MotorAsinBasketRobot.Business.Extensions;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Validator.Concrete
{
    public class ProductValidator:IProductValidator
    {
        private readonly IProductDal _productDal;
        private readonly ISpeCodeDal _speCodeDal;
        public ProductValidator(IProductDal productDal, ISpeCodeDal speCodeDal)
        {
            _productDal = productDal;
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

        public Task CheckUpdateAsync(int id, string code, Product entity)
        {
            throw new NotImplementedException();
        }

        //public async Task CheckCreateAsync(string code, Guid? speCode1Id, Guid? speCode2Id)
        //{
        //    await _productDal.CodeAnyAsync(code, x => x.ProductCode == code);
        //}

        //public Task CheckDeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task CheckUpdateAsync(Guid id, string code, Product entity, Guid? SpeCode1Id, Guid? SpeCode2Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
