using AppleStore.Service.Dtos.Notifications;

namespace AppleStore.Service.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
