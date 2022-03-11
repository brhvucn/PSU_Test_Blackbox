using BlackBox.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlackBox.API.Data
{
    public class CustomerData
    {
        private static CustomerData instance;
        private List<Customer> customers;
        private CustomerData()
        {
            this.customers = new List<Customer>();
        }

        static CustomerData()
        {
            instance = new CustomerData();
        }

        public static CustomerData Instance
        {
            get { return instance; }
        }

        public Customer Read(int id)
        {
            return this.customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> ReadAll()
        {
            return this.customers.ToList();
        }

        public void Create(Customer customer)
        {
            this.customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = Read(customer.Id);
            this.customers[this.customers.IndexOf(existingCustomer)] = customer;
        }

        public void Delete(int id)
        {
            this.customers.Remove(this.customers.FirstOrDefault(x=>x.Id == id));
        }
    }
}
