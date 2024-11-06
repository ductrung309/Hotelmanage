using HotelManage;
using System.Text;


namespace ConsoleApp1
{
    internal class Program
    {
        private static HotelManagementSystem hotelManagementSystem = new HotelManagementSystem();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
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
                Console.Write("Lựa chọn: ");
                string Choice = Console.ReadLine();
                Console.Clear();
                switch (Choice)
                {
                    case "1":
                        hotelManagementSystem.DisplayAvailableRooms();
                        forProgram.CheckIn(hotelManagementSystem);
                        break;
                    case "2":
                        hotelManagementSystem.DisplayAvailableRooms();
                        break;
                    case "3":
                        hotelManagementSystem.DisplayOccupiedRooms();
                        break;
                    case "4":
                        forProgram.AddService(hotelManagementSystem);
                        break;
                    case "5":
                        forProgram.Checkout(hotelManagementSystem);
                        break;
                    case "6":
                        hotelManagementSystem.AddRoom(forProgram.SetRoom(hotelManagementSystem));
                        break;
                    case "7":
                        hotelManagementSystem.AddService(forProgram.SetService());
                        break;

                }
            }
        }
    }
    internal class ForProgram
    {
        public void AddService(HotelManagementSystem hotelManagementSystem)
        {
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Guest guest = hotelManagementSystem._guest.FirstOrDefault(guest => guest.IDNumber == id);
            if (guest != null)
            {
                for (int i = 0; i < hotelManagementSystem._services.Count; i++)
                {
                    Console.Write($"{i + 1}\t");
                    Console.WriteLine(hotelManagementSystem._services[i].DisplayServiceInfo());
                }
                Console.Write("Th Service: ");
                int thservice = int.Parse(Console.ReadLine());
                guest.AddService(hotelManagementSystem._services[thservice - 1]);
                Console.WriteLine("Thêm dịch vụ thành công!");
            }
            else
            {
                Console.WriteLine("Không tồn tại ID khách hàng");
            }
        }
        public Service SetService()
        {
            Console.Write("Service Name: ");
            string servicename = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            return new Service(servicename, price);
        }
        public Room SetRoom(HotelManagementSystem hotelManagementSystem)
        {
            Console.Write("Room Type: ");
            string roomtype = Console.ReadLine();
            Console.Write("Price: ");
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
        public void CheckIn( HotelManagementSystem hotelManagementSystem)
        {
            Console.Write("Room Number: ");
            int id = int.Parse(Console.ReadLine());
            Room room = hotelManagementSystem._rooms.FirstOrDefault(room => room.RoomNumber == id);
            if(room == null)
            {
                Console.WriteLine("Không tồn tại phòng");
                return;
            }
            else if (room.IsOccupied)
            {
                Console.WriteLine("Phòng đã có người vui lòng đặt phòng khác");
            }
            else
            {
                Guest guest = this.SetGuest();
                guest.BookRoom(room);
                hotelManagementSystem._guest.Add(guest);
                Console.WriteLine("Đặt phòng thành công");
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
                            break;
                        }
                    }
                    using (StreamWriter console = new StreamWriter("DataCustomer.txt",true, System.Text.Encoding.UTF8))
                    {
                        console.WriteLine($"Name: {guest.Name}");
                        console.WriteLine($"Checkin Date: {guest.CheckInDate}");
                        console.WriteLine($"Checkout Date: {DateTime.Now}");
                        console.WriteLine(guest.Room.DisplayRoomInfo());
                        console.WriteLine("====================Dịch vụ===================");
                        foreach (Service service in guest.ServicesUsed)
                        {
                            console.Write(service.DisplayServiceInfo());
                        }
                        console.WriteLine("==============================================");
                        console.WriteLine($"Total: {guest.GetTotalBill()}đ");
                        console.WriteLine("\n-----------------------------------------------------\n");
                    }
                    hotelManagementSystem.GenerateInvoice(guest);
                    hotelManagementSystem._guest.Remove(guest);
                    Console.WriteLine("Trả phòng thành công!!");
                    break;
                }
            }
        }
    }
}
