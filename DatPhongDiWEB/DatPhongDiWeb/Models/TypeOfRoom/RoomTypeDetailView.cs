using System.Collections.Generic;

namespace DatPhongDiWeb.Models.TypeOfRoom
{
    public class RoomTypeDetailView
    {
        public string Name { get; set; }
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        public int PricePerNight { get; set; }
        public int Size { get; set; }
        public int AmountAvailableRoom { get; set; }
        public List<ImageView> Images { get; set; }
    }
}
