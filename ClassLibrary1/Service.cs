using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManage
{
    public class Service
    {
        //Field
        public string ServiceName;
        public decimal Price;
        
        //Method
        public Service(string ServiceName, decimal Price) {
            this.ServiceName = ServiceName;
            this.Price = Price;
        }
        public string DisplayServiceInfo()
        {
            return $"Service name: {this.ServiceName}\tPrice:{this.Price}\n";
        }
    }
}
