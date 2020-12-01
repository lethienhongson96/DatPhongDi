using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.Booking
{
    public class BookingView
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int AmountNight { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CheckInStr { get; set; }
        public string CheckOutStr { get; set; }
        public string CreateDateStr { get; set; }
        public string ModifiedDateStr { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
    }
}
