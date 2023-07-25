using AppleStore.DataAccess.Utils;

namespace AppleStore.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
