using System;

namespace DatPhongDi.Domain.Response.Booking
{
    public class BookingView
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int AmountNight { get; set; }
        public DateTime CheckIn { get; set; }
        public string CheckInStr { get; set; }
        public DateTime CheckOut { get; set; }
        public string CheckOutStr { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateStr { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateStr {get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
    }
}
