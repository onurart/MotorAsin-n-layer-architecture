namespace MotorAsinBasketRobot.Core.DataAccess.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpression { get; set; }
        public string SecurityKey { get; set; }
    }
}
