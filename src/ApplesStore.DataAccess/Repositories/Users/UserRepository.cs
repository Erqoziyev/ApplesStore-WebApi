﻿using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.DataAccess.Interfaces.Users;
using AppleStore.DataAccess.Utils;
using AppleStore.DataAccess.ViewModels.Users;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Domain.Entities.Users;
using Dapper;

namespace AppleStore.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from users";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(first_name, last_name, phone_number, passport_seria, is_male, region, password_hash, salt, image_path, identity_role, created_at, updated_at) " +
                $"VALUES (@FirstName, @LastName, @PhoneNumber, @PassportSeria, @IsMale, @Region, @PasswordHash, @Salt, @ImagePath, @IdentityRole, @CreatedAt, @UpdatedAt);";
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
            string query = $"delete from users where id = {id}";
            return await _connection.ExecuteAsync(query);
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

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
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

    public async Task<User?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM users where id=@Id";
            var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });
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

    public Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.users " +
                           $"SET first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, passport_seria=@PassportSeria, is_male=@IsMale, region=@Region, password_hash=@PasswordHash, salt=@Salt, image_path=@ImagePath, identity_role=@IdentityRole, created_at=@CreatedAt, updated_at=@UpdatedAt\r\n " +
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

    async Task<IList<User>> IGetAll<User>.GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM categories order by id desc " +
                $"offset {@params.SkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<User>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<User>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}

