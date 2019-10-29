using System;

namespace CustomerHub.Domain.Customer.Builder
{
    public class CustomerBuilder : ICustomerBuilder
    {
        private Customer _customer = new Customer();

        public Customer GetCustomer()
        {
            return _customer;
        }

        public void SetDocumentNumber(string documentNumber)
        {
            _customer.DocumentNumber = documentNumber;
        }

        public void SetEmail(string email)
        {
            _customer.Email = email;
        }

        public void SetName(string name)
        {
            _customer.Name = name;
        }

        public void SetNextPayment(DateTime nextPayment)
        {
            _customer.NextPayment = nextPayment;
        }
    }
}