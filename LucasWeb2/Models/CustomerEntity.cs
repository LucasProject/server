using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucasWeb2.Models
{
    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(Customer customer)
        {
            this.PartitionKey = customer.PhoneNumber;
            this.RowKey = customer.EmailAddress;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
        }

        public CustomerEntity() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
