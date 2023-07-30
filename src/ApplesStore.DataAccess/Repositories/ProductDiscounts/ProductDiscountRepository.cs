using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.DataAccess.Interfaces;
using AppleStore.DataAccess.Interfaces.Discounts;
using AppleStore.DataAccess.Interfaces.ProductDiscounties;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Discounts;
using AppleStore.Domain.Entities.Products;
using Dapper;
using System.Collections.Generic;

namespace AppleStore.DataAccess.Repositories.ProductDiscounts;

public class ProductDiscountRepository : BaseRepository, IProductDiscountRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select count(*) from product_discounts";

            return await _connection.QuerySingleAsync<long>(query);
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Domain.Entities.Products.ProductDiscount entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.product_discounts(product_id, discount_id, start_at, end_at, percentage, description, created_at, updated_at)" +
                           "VALUES (@ProductId, @DiscountId, @StartAt, @EndAt, @Percentage, @Description, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            _connection.Close();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM public.product_discounts " +
                           "WHERE id = Id;";

            return await _connection.ExecuteAsync(query, new { Id = id });
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Domain.Entities.Products.ProductDiscount>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * from products order by id desc " +
                $" offset {@params.SkipCount} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Domain.Entities.Products.ProductDiscount>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<Domain.Entities.Products.ProductDiscount>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Domain.Entities.Products.ProductDiscount> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM product_discounts where id=@Id";
            var result = await _connection.QuerySingleAsync<Domain.Entities.Products.ProductDiscount>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Domain.Entities.Products.ProductDiscount entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.product_discounts " +
                           "SET product_id = @ProductId, discount_id = @DiscountId, start_at = @StartAt, end_at = @EndAt, percentage = @Percentage, description = @Description, created_at = @CreatedAt, updated_at = @UpdatedAt " +
                          $"WHERE id = {id}; ";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<(int ItemsCount, IList<Domain.Entities.Products.ProductDiscount>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }
}
