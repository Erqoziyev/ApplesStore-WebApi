using AppleStore.Domain.Constans;

namespace AppleStore.Service.Common.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstans.UTC);
        return dtTime;
    }
}

