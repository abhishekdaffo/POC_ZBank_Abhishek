﻿using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception is thrown for Customer Not Found
    /// </summary>
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(Guid customerId)
            : base($"The customer with the Id {customerId} was not found.")
        {
        }
    }
}