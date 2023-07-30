using AppleStore.DataAccess.Interfaces.Deliveries;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Domain.Entities.Deliveries;
using Dapper;
using System.Collections.Generic;

namespace AppleStore.DataAccess.Repositories.Deliveries;

public class DeliveryRepository : BaseRepository, IDeliveryRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT count(*) FROM deliveries";

            var result = await _connection.QuerySingleAsync<long>(query);
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

    public async Task<int> CreateAsync(Delivery entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.deliveries" +
                "(first_name, last_name, phone_number, passport_seria, is_male, region, password_hash, salt, image_path, created_at, updated_at)" +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @PassportSeria, @IsMale, @Region, @PasswordHash, @Salt, @ImagePath, @CreatedAt, @UpdatedAt);";

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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM deliveries WHERE id = @Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
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

    public async Task<IList<Delivery>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM deliveries order by id desc " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Delivery>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Delivery>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Delivery?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM deliveries Where id=@Id";
            var result = await _connection.QuerySingleAsync<Delivery>(query, new { Id = id });
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

    public Task<Delivery> GetDeliverAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Delivery entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.deliveries " +
                           $"SET first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, passport_seria=@PassportSeria, is_male=@IsMale, region=@Region, password_hash=@PasswordHash, salt=@Salt, image_path=@ImagePath, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                           $"WHERE id={id};";

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
}
