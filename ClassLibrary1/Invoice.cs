using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManage
{
    public class Invoice
    {
        //Field
        private Guest Guest;
        private decimal TotalAmount;
        private DateTime Date;

        //Method]
        public Invoice(Guest guest)
        {
            TotalAmount = 0;
            Date = DateTime.Now;
            Guest = guest;
        }
        public void GenerateInvoice()
        {
            TotalAmount = Guest.GetTotalBill();
        }
        public void PrintInvoice()
        {
            Console.WriteLine($"Name: {Guest.Name}");
            Console.WriteLine($"Checkin Date: {Guest.CheckInDate}");
            Console.WriteLine($"Checkout Date: {DateTime.Now}");
            Console.WriteLine(Guest.Room.DisplayRoomInfo());
            Console.WriteLine("===============Dịch vụ=================");
            foreach(Service service in Guest.ServicesUsed)
            {
                Console.WriteLine(service.DisplayServiceInfo());
            }
            Console.WriteLine("=======================================");
            Console.WriteLine($"Total: {TotalAmount}đ");
        }
    }
}
