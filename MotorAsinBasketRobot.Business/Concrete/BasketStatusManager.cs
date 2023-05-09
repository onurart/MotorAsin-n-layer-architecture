using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.BasketStatus;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class BasketStatusManager : IBasketStatusService
    {
        private readonly IBasketStatusDal _basketStatusDal;
        private readonly IBasketStatusValidator _basketStatusValidator;

        public BasketStatusManager(IBasketStatusDal basketStatusDal, ISpeCodeDal speCodeDal)
        {
            _basketStatusDal = basketStatusDal;
            _basketStatusValidator = new BasketStatusValidator(_basketStatusDal, speCodeDal);
        }

        public async Task<IDataResult<BasketStatus>> Create(BasketStatus entity)
        {
            try
            {
                await _basketStatusValidator.CheckCreateAsync(entity.Code);
                return new SuccessDataResult<BasketStatus>(await _basketStatusDal.CreateAsync(entity), Messages.BasketStatusAdded);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<BasketStatus>(ex.Message);
                throw;
            }
        }
        public async Task<IDataResult<BasketStatus>> Delete(BasketStatus entity)
        {
            try
            {
                return new SuccessDataResult<BasketStatus>(await _basketStatusDal.DeleteAsync(entity), Messages.BasketStatusDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<BasketStatus>(ex.Message);
            }
        }
        public async Task<IDataResult<BasketStatus>> Get(int id)
        {
            try
            {
                return new SuccessDataResult<BasketStatus>(await _basketStatusDal.GetAsync(id, b => b.Id == id), Messages.BasketStatusGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<BasketStatus>(ex.Message);
            }
        }
        public async Task<IDataResult<string>> GetCode(BasketStatusCodeParameterDto parameterDto)
        {
            try
            {
                return new SuccessDataResult<string>(await _basketStatusDal.GetCodeAsync(x => x.Code, x => x.IsActive == parameterDto.Statu), Messages.BasketStatussGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
        }
        public async Task<IDataResult<IList<BasketStatus>>> GetList(BasketStatusListParameterDto parameterDto)
        {
            try
            {
                return new SuccessDataResult<IList<BasketStatus>>
               (await _basketStatusDal.GetListAsync(b => b.IsActive == parameterDto.Statu, b => b.Code), Messages.BasketStatussGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<BasketStatus>>(ex.Message);
            }
        }
        public async Task<IDataResult<BasketStatus>> Update(BasketStatus entity)
        {
            try
            {
                await _basketStatusValidator.CheckUpdateAsync(entity.Id, entity.Code, entity);
                return new SuccessDataResult<BasketStatus>(await _basketStatusDal.UpdateAsync(entity), Messages.BasketStatusUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<BasketStatus>(entity, ex.Message);
            }
        }
    }
}
