namespace HotelManage
{
    public class Room
    {
        //Field
        public int RoomNumber { get; private set; }
        private string RoomType;
        private decimal PricePerNight;
        public bool IsOccupied { get; private set; }

        //Method
        public Room(int RoomNumber, string RoomType, decimal PricePerNight)
        {
            this.RoomNumber = RoomNumber;
            this.RoomType = RoomType;
            this.PricePerNight = PricePerNight;
            this.IsOccupied = false;
        }

        public void CheckIn()
        {
            IsOccupied = true;
        }
        public void CheckOut()
        {
            IsOccupied = false;
        }
        public decimal CalculateBill(int nights)
        {
            return nights * PricePerNight;
        }
        public String DisplayRoomInfo()
        {
            return $"Room Number: {this.RoomNumber}\tRoom Type: {this.RoomType}\tPrice Per Night: {this.PricePerNight}\n";
        }
    }
}