namespace AppleStore.Service.Dtos.Notifications;

public class SmsMessage
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
