using System;

namespace CustomerHub.Domain.Customer
{
    public interface ICustomer
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string DocumentNumber { get; set; }
        DateTime NextPayment { get; set; }
    }
}