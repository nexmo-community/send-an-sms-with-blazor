using Microsoft.Extensions.Configuration;
using Nexmo.Api.Messaging;
using Nexmo.Api.Request;

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
            var apiKey = Configuration["NEXMO_API_KEY"];
            var apiSecret = Configuration["NEXMO_API_SECRET"];
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