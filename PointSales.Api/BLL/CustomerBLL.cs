using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.Extensions.Configuration;

namespace Jcvalera.Core.BLL
{
    public class CustomerBLL : ICustomerBLL
    {
        public IConfiguration Configuration;

        public ICustomerDAL CustomerDAL;

        public CustomerBLL(IConfiguration configuration)
        {
            CustomerDAL = new CustomerDAL(configuration);
        }

        public async Task SaveCustomer(Customer customer)
        {
            try
            {
                await CustomerDAL.SaveCustomer(customer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Customer> GetCustomer(int idCustomer)
        {
            try
            {
                var customer = new Customer();

                customer = await CustomerDAL.GetCustomer(idCustomer);

                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = new List<Customer>();

                customers = await CustomerDAL.GetAllCustomers();

                return customers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                await CustomerDAL.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteCustomer(int idCustomer)
        {
            try
            {
                await CustomerDAL.DeleteCustomer(idCustomer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
