using MotorAsinBasketRobot.Business.Extensions;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
namespace MotorAsinBasketRobot.Business.Validator.Concrete
{
    public class BasketStatusValidator : IBasketStatusValidator
    {
        private readonly IBasketStatusDal _basketStatusDal;
        private readonly ISpeCodeDal _speCodeDal;

        public BasketStatusValidator(IBasketStatusDal basketStatusDal, ISpeCodeDal speCodeDal)
        {
            _basketStatusDal = basketStatusDal;
            _speCodeDal = speCodeDal;
        }

        public async Task CheckCreateAsync(string code)
        {
            throw new NotImplementedException();
            //await _basketStatusDal.CodeAnyAsync(code,x => x.Code == code);
        }
        public async Task CheckUpdateAsync(int id, string code, BasketStatus entity)
        {
            throw new NotImplementedException();
            //await _basketStatusDal.CodeAnyAsync(code, x => x.Id != id && x.Code == code, entity.Code != code);
        }
    }
}
