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
    public class SpeCodeValidator : ISpeCodeValidator
    {
        private readonly ISpeCodeDal _speCodeDal;
        public SpeCodeValidator(ISpeCodeDal speCodeDal)
        {
            _speCodeDal = speCodeDal;
        }
        public async Task CheckCreateAsync(string code, SpeCodeType? speCodeType, SpeCodeCardType? speCodeCardType)
        {
            await _speCodeDal.CodeAnyAsync(code, x => x.Code == code && x.SpeCodeType == speCodeType && x.SpeCodeCardType == speCodeCardType);
        }

        public Task CheckCreateAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task CheckDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CheckUpdateAsync(int id, string code, SpeCode entity)
        {
            await _speCodeDal.CodeAnyAsync(code, x => x.Id != id && x.Code == code && x.SpeCodeType == entity.SpeCodeType && x.SpeCodeCardType == entity.SpeCodeCardType);
        }
        //public async Task CheckDeleteAsync(Guid id)
        //{
        //    await _speCodeDal.RelationalEntityAnyAsync(x => x.Code.Any(x => x.SpeCode1Id == id) || x.SpeCodes2Company.Any(x => x.SpeCode2Id == id)
        //                                   || x.SpeCodes1Contract.Any(x => x.SpeCode1Id == id) || x.SpeCodes2Contract.Any(x => x.SpeCode2Id == id)
        //                                   || x.SpeCodes1Department.Any(x => x.SpeCode1Id == id) || x.SpeCodes2Department.Any(x => x.SpeCode2Id == id)
        //                                   || x.SpeCodes1Employee.Any(x => x.SpeCode1Id == id) || x.SpeCodes2Employee.Any(x => x.SpeCode2Id == id)
        //                                   || x.SpeCode1Items.Any(x => x.SpeCode1Id == id) || x.SpeCode1Items.Any(x => x.SpeCode2Id == id)
        //                                   || x.SpeCode1LaborServices.Any(x => x.SpeCode1Id == id) || x.SpeCode2LaborServices.Any(x => x.SpeCode2Id == id)
        //                                   || x.SpeCodes1NetlineTicket.Any(x => x.SpeCode1Id == id) || x.SpeCodes2NetlineTicket.Any(x => x.SpeCode2Id == id)
        //                                   || x.SpeCode1Units.Any(x => x.SpeCode1Id == id) || x.SpeCode2Units.Any(x => x.SpeCode2Id == id));
        //}
    }
}
