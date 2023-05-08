using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MotorAsinBasketRobot.Core.DataAccess.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
