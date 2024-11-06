using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManage
{
    public class HotelManagementSystem
    {
        //Field
        public List<Room> _rooms { get; set; }
        public List<Guest> _guest;
        public List<Service> _services { get; set; }

        //Method
        public HotelManagementSystem()
        {
            _rooms = new List<Room>() { new Room(001, "Double", 1000000),
                                        new Room(002, "Single", 500000),
                                        new Room(003, "Single", 200000),
                                        new Room(004, "Double", 850000),
                                        new Room(005, "Single", 4000000),
                                        new Room(006, "Double", 500000),
                                        new Room(007, "Double", 420000),
                                        new Room(008, "Single", 700000),
                                        new Room(009, "Double", 2000000),
                                        new Room(0010, "Single", 100000),
            };
            _guest = new List<Guest>();
            _services = new List<Service>(){new Service("Laundry", 100000),
                                            new Service("Room Service", 200000),
                                            new Service("Spa", 300000),
                                            new Service("Swimming Pool", 150000),
                                            new Service("Gym", 100000),
                                            new Service("Airport Shuttle", 500000),
                                            new Service("Massage", 400000),
                                            new Service("Breakfast", 150000),
                                            new Service("Conference Room", 1000000)
            };
        }
        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }
        public void AddGuest(Guest guest)
        {
            _guest.Add(guest);
        }
        public void AddService(Service service)
        {
            _services.Add(service);
        }
        public void GenerateInvoice(Guest guest)
        {
            Invoice invoice = new Invoice(guest);
            invoice.GenerateInvoice();
            invoice.PrintInvoice();
        }
        public void DisplayOccupiedRooms()
        {
            foreach (Room room in _rooms)
            {
                if (room.IsOccupied)
                {
                    Console.WriteLine(room.DisplayRoomInfo());
                }
            }
        }
        public void DisplayAvailableRooms()
        {
            foreach (Room room in _rooms)
            {
                if (!room.IsOccupied)
                {
                    Console.WriteLine(room.DisplayRoomInfo());
                }
            }
        }
    }
}
