using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerEnvironmentViewer.Model
{
    public class Environment : Customer
    {
        public string EnvironmentName { get; set; }

        public string EnvironmentDirectory { get; set; }

        public EnvironmentDetails Details { get; set; }
    }
}
