using System;

namespace CustomerHub.Domain.Customer.Builder
{
    public interface ICustomerBuilder
    {
        void SetName(string name);

        void SetEmail(string email);

        void SetDocumentNumber(string documentNumber);

        void SetNextPayment(DateTime nextPayment);

        Customer GetCustomer();
    }
}