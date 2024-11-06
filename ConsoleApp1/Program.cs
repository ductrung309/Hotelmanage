using HotelManage;

namespace ConsoleApp1
{
    internal class Program
    {
        private static HotelManagementSystem hotelManagementSystem = new HotelManagementSystem();
        static void Main(string[] args)
        {
            ForProgram forProgram = new ForProgram();
            while (true)
            {
                
                Console.WriteLine("======================================");
                Console.WriteLine("1.Book Phòng");
                Console.WriteLine("2.Hiển thị danh sách phòng trống");
                Console.WriteLine("3.Hiển thị danh sách phòng đã được đặt");
                Console.WriteLine("4.Sử dụng dịch vụ");
                Console.WriteLine("5.Trả phòng và in hóa đơn");
                Console.WriteLine("6.AddRoom");
                Console.WriteLine("7.AddService");
                
                Console.WriteLine("Lựa chọn: ");
                string Choice = Console.ReadLine();
                Console.Clear();
                switch (Choice)
                {
                    case "1":
                        Guest guest = forProgram.SetGuest();
                        hotelManagementSystem.AddGuest(guest);
                        forProgram.CheckIn(guest, hotelManagementSystem);
                        break;
                    case "2":
                        hotelManagementSystem.DisplayAvailableRooms();
                        break;
                    case "3":
                        hotelManagementSystem.DisplayOccupiedRooms();
                        break;
                    case "4":

                        break;
                    case "5":
                        hotelManagementSystem.AddRoom(forProgram.SetRoom(hotelManagementSystem));
                        break;
                    case "6":
                        hotelManagementSystem.AddService(forProgram.SetService());
                        break;
                }
            }
        }
    }
    internal class ForProgram
    {
        public Service SetService()
        {
            Console.WriteLine("Service Name: ");
            string servicename = Console.ReadLine();
            Console.WriteLine("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            return new Service(servicename, price);
        }
        public Room SetRoom(HotelManagementSystem hotelManagementSystem)
        {
            Console.WriteLine("Room Type: ");
            string roomtype = Console.ReadLine();
            Console.WriteLine("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            return new Room(hotelManagementSystem._rooms[^1].RoomNumber+1, roomtype, price);
        }
        public Guest SetGuest()
        {
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("ID: ");
            string IDNumber = Console.ReadLine();
            return new Guest(Name, IDNumber);
        }
        public void CheckIn(Guest guest, HotelManagementSystem hotelManagementSystem)
        {
            Console.Write("Số phòng muốn đặt: ");
            int id = int.Parse(Console.ReadLine());
            foreach(Room room in hotelManagementSystem._rooms)
            {
                if (room.RoomNumber == id)
                {
                    guest.BookRoom(room);
                    break;
                }
                
            }
        }
        public void Checkout( HotelManagementSystem hotelManagementSystem)
        {
            Console.Write("ID: ");
            string id = Console.ReadLine();
            foreach(Guest guest in hotelManagementSystem._guest)
            {
                if(guest.IDNumber == id)
                {
                    foreach(Room room in hotelManagementSystem._rooms)
                    {
                        if(guest.Room.RoomNumber == room.RoomNumber)
                        {
                            room.CheckOut();
                        }
                    }
                    hotelManagementSystem.GenerateInvoice(guest);
                    Console.WriteLine("Trả phòng thành công!!");
                    break;
                }
            }
            
        }
    }
}
