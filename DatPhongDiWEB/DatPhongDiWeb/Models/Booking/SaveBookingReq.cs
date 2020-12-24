using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.Booking
{
    public class SaveBookingReq
    {
        public int Id { get; set; }
        public int AmountNight { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Status { get; set; }
        public double TotalPrice { get; set; }
    }
}
