using Microsoft.Extensions.Configuration;
using Vonage.Messaging;
using Vonage.Request;

namespace SendSmsBlazor.Data
{
    public class SmsService
    {
        public IConfiguration Configuration { get; set; }
        public SmsService(IConfiguration config)
        {
            Configuration = config;
        }

        public SendSmsResponse SendSms(string to, string from, string text)
        {
            var apiKey = Configuration["VONAGE_API_KEY"];
            var apiSecret = Configuration["VONAGE_API_SECRET"];
            var creds = Credentials.FromApiKeyAndSecret(apiKey,apiSecret);
            var client = new SmsClient(creds);
            var request = new SendSmsRequest
            {
                To= to,
                From = from,
                Text = text
            };
            return client.SendAnSms(request);
        }
    }
}