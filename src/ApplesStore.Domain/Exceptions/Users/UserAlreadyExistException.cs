using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStore.Domain.Exceptions.Users;

public class UserAlreadyExistException : AlreadyExistsException
{
    public UserAlreadyExistException()
    {
        TitleMessage = "User already exists";
    }

    public UserAlreadyExistException(string phone)
    {
        TitleMessage = "This phone is already registered";
    }
}
