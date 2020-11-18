using System;

namespace DatPhongDi.Domain.Request.Booking
{
    public class SaveBookingRed
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }

        public int AmountNight { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public int Status { get; set; }
    }
}
