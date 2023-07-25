﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStore.Domain.Exceptions.Auth;

public class VerificationTooManyRequestsException : TooManyRequestException
{
    public VerificationTooManyRequestsException()
    {
        TitleMessage = "You tried more than limits!";
    }
}
