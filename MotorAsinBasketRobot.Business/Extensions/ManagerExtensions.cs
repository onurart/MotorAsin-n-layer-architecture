using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Extensions
{
    public static class ManagerExtensions
    {
        public static void RemoveAll<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                source.Remove(item);
            }
        }
    }
}
