﻿using AppleStore.DataAccess.Utils;

namespace AppleStore.DataAccess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
