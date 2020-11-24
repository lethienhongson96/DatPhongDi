using System;

namespace DatPhongDiWeb.Models.Booking
{
    public class SaveBookingReq
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int AmountNight { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Status { get; set; }
    }
}
