using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Api;

namespace LauncherGames.DAL.Helpers
{
    public static class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PayPalConfiguration()
        {
            ClientId = "AVRL3PbuoimUYPTzqUbXCWoNffEsx72ewcU9GAyNcVYjAnEKP7V0qDM5rG21KKBN7caXrxiuOAplaGX7";
            ClientSecret = "EOrCwF61saN5hzL6W7eRfbL9qBlF7m7wO8RbATTIhZ0gZle2u09MQPiHUiF6VQM3ErFV8Egu-7tyt2GK";
        }

        public static APIContext GetAPIContext()
        {
            var config = ConfigManager.Instance.GetProperties();
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, config).GetAccessToken();
            return new APIContext(accessToken);
        }
    }
}
