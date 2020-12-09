using DatPhongDi.Domain.Response.Image;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Request.TypeOfRoom
{
    public class RoomTypeDetailView
    {
        public string Name { get; set; }
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        public int PricePerNight { get; set; }
        public int Size { get; set; }
        public int AmountAvailableRoom { get; set; }
    }
}
