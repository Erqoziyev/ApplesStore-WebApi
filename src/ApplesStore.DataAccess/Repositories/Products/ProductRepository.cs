using AppleStore.DataAccess.Interfaces.Products;
using AppleStore.DataAccess.Utils;
using AppleStore.DataAccess.ViewModels.Products;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Domain.Entities.Products;
using Dapper;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;

namespace AppleStore.DataAccess.Repositories.Products;

public class ProductRepository : BaseRepository, IProductRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select count(*) from products";

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

    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.products(category_id, name, image_path, color, price, description, created_at, updated_at)" +
                           "VALUES(@CategoryId, @Name, @ImagePath, @Color, @Price, @Description, @CreatedAt, @UpdatedAt); ";

            return await _connection.ExecuteAsync(query, entity);
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Delete from products where id=@Id";

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

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * from products order by id desc " +
                $" offset {@params.SkipCount} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Product>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Product> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM products where id=@Id";
            var result = await _connection.QuerySingleAsync<Product>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.products " +
                            "SET  name = @Name, description = @Description, color = @Color, image_path = @ImagePath, price = @Price,  updated_at = @UpdatedAt" +
                           $" WHERE id = {id};";
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

    public Task<(int ItemsCount, IList<ProductViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }
}
