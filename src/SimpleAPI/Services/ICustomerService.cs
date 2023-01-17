using SimpleAPI.Models;

namespace SimpleAPI.Services
{
    public interface ICustomerService
    {
        Task<IList<Customer>> List();
        Task<Customer> GetCustomer(int id);
        Task SaveCustomer(Customer customer);
    }
}