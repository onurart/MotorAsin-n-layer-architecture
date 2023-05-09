using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.SpeCodeListParameterDto;
using MotorAsinBasketRobot.Entities.Dtos.SpeCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class SpeCodeManager : ISpeCodeService
    {
        private readonly ISpeCodeValidator _validator;
        private readonly ISpeCodeDal speCodeDal;
        public SpeCodeManager(ISpeCodeDal _speCodeDal)
        {
            speCodeDal = _speCodeDal;
            _validator = new SpeCodeValidator(speCodeDal);
        }

        public Task<IDataResult<SpeCode>> Create(SpeCode entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SpeCode>> Delete(SpeCode entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SpeCode>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<string>> GetCode(SpeCodeParameterDto parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IList<SpeCode>>> GetList(SpeCodeListParameterDto parameter)
        {
            try
            {
                return  new  SuccessDataResult<IList<SpeCode>>(await speCodeDal.GetListAsync(b => b.Statu == parameter.Statu,b => b.Code,null), Messages.CustomerGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<SpeCode>>(ex.Message);
            }
        }

        public Task<IDataResult<PagedResult<SpeCode>>> GetPagedList(SpeCodeListParameterDto parameter)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SpeCode>> Update(SpeCode entity)
        {
            throw new NotImplementedException();
        }
    }
}
