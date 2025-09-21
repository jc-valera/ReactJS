using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface ICustomerBLL
    {
        Task SaveCustomer(Customer customer);

        Task<Customer> GetCustomer(int idCustomer); //By id

        Task<List<Customer>> GetAllCustomers();

        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(int idCustomer);
    }
}
