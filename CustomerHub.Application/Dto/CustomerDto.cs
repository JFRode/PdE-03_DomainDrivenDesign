using System;

namespace CustomerHub.Application.Dto
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime NextPayment { get; set; }
    }
}