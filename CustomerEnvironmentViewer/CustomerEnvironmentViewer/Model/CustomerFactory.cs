using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerEnvironmentViewer.Model
{
    public class CustomerFactory
    {
        public async Task<List<Customer>> GetCustomerCollectionAsync()
        {
            return await Task.Run(() =>
            {
                return new List<Customer>();
            });
        }

        private List<Customer> DoGetCustomerCollection()
        {
            return new List<Customer>();
        }
    }
}
