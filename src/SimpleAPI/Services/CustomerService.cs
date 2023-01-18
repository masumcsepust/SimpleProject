using Microsoft.EntityFrameworkCore;
using SimpleAPI.Data;
using SimpleAPI.Models;
using SimpleAPI.Services;


    public class CustomerService: ICustomerService
    {
        private readonly DemoDbContext _dataContext;

        public CustomerService(DemoDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _dataContext.customers.FindAsync(id);
            if(customer == null)
            {
                return null;
            }

            var model = new Customer();
            model.Id = customer.Id;
            model.Address = customer.Address;
            model.Email = customer.Email;
            model.Name = customer.Name;

            return model;
        }

        public async Task<IList<Customer>> List()
        {
            return await _dataContext.customers
                                     .OrderBy(c => c.Name)
                                     .Select(c => new Customer
                                     { 
                                        Id = c.Id,
                                        Name = c.Name,
                                        Address = c.Address,
                                        Email = c.Email
                                     })
                                     .ToListAsync();
        }

        public async Task SaveCustomer(Customer model)
        {
            var customer = new Customer();
            if(model.Id != 0)
            {
                customer = await _dataContext.customers.FirstOrDefaultAsync(c => c.Id == model.Id);
            }
            else
            {
                await _dataContext.customers.AddAsync(customer);
            }

            customer.Address = model.Address;
            customer.Email = model.Email;
            customer.Name = model.Name;

            await _dataContext.SaveChangesAsync();
        }
    }
