using MotorAsinBasketRobot.Core.DataAccess.Abstract;
using MotorAsinBasketRobot.Core.Entities.Abstract;
using System.Linq.Expressions;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Shared.Enums;
namespace MotorAsinBasketRobot.Business.Extensions
{
    public static class EntityAsyncExtensions
    {
        public static async Task CodeAnyAsync<T> (this IEntityRepository<T> repository, string kod,Expression<Func<T,bool>> predicate,bool check=true) where T : class,IBaseEntity
        {
            
            if (check && await repository.GetAnyAsync(predicate))
                throw new Exception("Aynı kod değerini kullanan veri bulunmaktadır!");
        }
        public static async Task EntityAnyAsync<T>(this IReadOnlyRepository<T> repository, object id, Expression<Func<T, bool>> predicate, bool check = true) where T : class, IBaseEntity
        {
            if (check && id != null)
            {
                if (!await repository.GetAnyAsync(predicate))
                    throw new Exception("Bu veri bulunamadı! Id : " + id.ToString());
            }
        }
        public static async Task EntityAnyAsync( this IReadOnlyRepository<SpeCode> repository, int? id, SpeCodeType speCodeType, SpeCodeCardType speCodeCardType, bool check = true)
        {
            if (check && id != null)
            {
                if (!await repository.GetAnyAsync(x => x.Id == id && x.SpeCodeType == speCodeType && x.SpeCodeCardType == speCodeCardType))
                    throw new Exception("Bu özel kod bulunamadı! Id : " + id.ToString());
            }
        }
        public static async Task RelationalEntityAnyAsync<TEntity>(this IReadOnlyRepository<TEntity> repository,Expression<Func<TEntity, bool>> predicate) where TEntity : class, IBaseEntity
        {
            if (await repository.GetAnyAsync(predicate))
                throw new Exception("Birbirine bağlı veriler silinemedi!");
        }
    }
}
