using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerHub.Domain.Customer
{
    public class Customer : ICustomer
    {
        public Guid Id { get; set; }

        [MaxLength(255)]
        [MinLength(5)]
        public string Name { get; set; }

        [MaxLength(255)]
        [MinLength(5)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string DocumentNumber { get; set; }

        public DateTime NextPayment { get; set; }
    }
}