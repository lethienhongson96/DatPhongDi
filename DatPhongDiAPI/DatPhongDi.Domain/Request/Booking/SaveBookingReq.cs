using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Request.Booking
{
    public class SaveBookingReq
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int AmountNight { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime CheckOut { get; set; }
        public int Status { get; set; }
    }
}
