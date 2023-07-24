using AppleStore.Service.Dtos.Notifications;
using AppleStore.Service.Interfaces.Notifications;

namespace AppleStore.Service.Services.Notifications;

public class SmsSender : ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage)
    {
        throw new NotImplementedException();
    }
}
