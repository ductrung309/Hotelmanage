using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManage
{
    public class Guest
    {
        //Field
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public DateTime CheckInDate { get; private set; }
        public Room Room { get; set; }
        public List<Service> ServicesUsed { get; private set; }

        //Method
        public Guest(string Name, string IDNumber)
        {
            this.IDNumber = IDNumber;
            this.CheckInDate = DateTime.Now;
            ServicesUsed = new List<Service>();
            this.Name = Name;
        }
        public void BookRoom(Room room)
        {
            Room = room;
            Room.CheckIn();
            room.DisplayRoomInfo();
        }
        public void AddService(Service service)
        {
            ServicesUsed.Add(service);
        }
        public decimal GetTotalBill()
        {
            decimal total =  Room.CalculateBill((DateTime.Now - CheckInDate).Days); 
            foreach (Service service in ServicesUsed)
            {
                total += service.Price;
            }
            return total;
        }
    }
}
