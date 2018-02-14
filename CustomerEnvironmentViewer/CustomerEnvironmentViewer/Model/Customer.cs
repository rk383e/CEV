using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerEnvironmentViewer.Model
{
    public class Customer
    {
        public string CustomerName { get; set; }

        public string CustomerDirectory { get; set; }

        public List<Environment> EnvironmentCollection { get; set; }
    }
}
