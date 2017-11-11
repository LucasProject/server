using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LucasWeb2.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace LucasWeb2.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "item1", "item2" };
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=lucas17;AccountKey=3iFhSaj/WJczjrihOZmZsP94hhEIlvsFlOPKmq74BqjiGEkMBuqAwHSs5xa6CykiV5rspEOnEXctcwHGVjntzw==;EndpointSuffix=core.windows.net");
            //CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            //CloudTable peopleTable = tableClient.GetTableReference("people");
            //TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1231231234"));

            //foreach(CustomerEntity entity in peopleTable.ExecuteQuerySegmentedAsync()

        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody]Customer newCustomer)
        {
            // go to keyvault and get connection string to storage account.
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=lucas17;AccountKey=3iFhSaj/WJczjrihOZmZsP94hhEIlvsFlOPKmq74BqjiGEkMBuqAwHSs5xa6CykiV5rspEOnEXctcwHGVjntzw==;EndpointSuffix=core.windows.net"; // <-- set connection string here            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("people");

            CustomerEntity customerEntity = new CustomerEntity(newCustomer);
            TableOperation insertOperation = TableOperation.Insert(customerEntity);
            table.ExecuteAsync(insertOperation);
        }
        
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
