using BlackBox.API.Data;
using BlackBox.API.Model;
using EnsureThat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackBox.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return CustomerData.Instance.ReadAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Customer GetCustomer(int id)
        {
            Ensure.That(id).IsGt(0);            
            return CustomerData.Instance.Read(id);
        }

        [HttpPost]
        public void CreateCustomer(Customer customer)
        {
            Ensure.That(customer.Name).IsNotNullOrEmpty();
            CustomerData.Instance.Create(customer);
        }

        [HttpPut]
        public void UpdateCustomer(Customer customer)
        {
            Ensure.That(customer.Name).IsNotNullOrEmpty();
            Ensure.That(customer.Id).IsGt(0);
            CustomerData.Instance.Update(customer);
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            Ensure.That(id).IsGt(id);
            CustomerData.Instance.Delete(id);
        }
    }
}
