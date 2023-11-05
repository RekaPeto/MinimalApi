using test.Models;

namespace test.Repositories
{
    interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
        void Delete(int id);

    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<int, Customer> _customers = new();

        public CustomerRepository()
        {
            _customers.Add(1, new Customer(1, "abc dcg"));
        }

        public void Create(Customer customer)
        {
            if (customer is null)
            {
                return;
            }

            _customers[customer.Id] = customer;
        }

        public Customer GetById(int id)
        {
            return _customers[id];
        }

        public List<Customer> GetAll()
        {
            return _customers.Values.ToList();
        }

        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.Id);
            if (existingCustomer is null)
            {
                return;
            }

            _customers[customer.Id] = customer;
        }

        public void Delete(int id)
        {
            _customers.Remove(id);
        }
    }
}
