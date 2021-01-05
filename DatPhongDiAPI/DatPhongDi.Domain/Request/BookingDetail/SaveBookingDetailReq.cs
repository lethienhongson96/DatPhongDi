using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Request.BookingDetail
{
    public class SaveBookingDetailReq
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public double Price { get; set; }
    }
}
