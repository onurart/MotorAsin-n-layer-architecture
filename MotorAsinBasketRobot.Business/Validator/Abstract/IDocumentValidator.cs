using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketRobot.Business.Validator.Abstract
{
    public interface IDocumentValidator
    {
        Task CheckCreateAsync(string code);
        Task CheckUpdateAsync(int id, string code, Documents entity);
        Task CheckDeleteAsync(int id);
    }
}
