﻿namespace AppleStore.DataAccess.Utils;

public class PaginationParams
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public PaginationParams(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int SkipCount ()
    {
       return (PageNumber - 1) * PageSize;
    }
}
