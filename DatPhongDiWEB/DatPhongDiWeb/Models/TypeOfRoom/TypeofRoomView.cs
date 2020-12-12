using DatPhongDiWeb.Models.Service;
using DatPhongDiWeb.Models.TypeOfRoomService;
using System;
using System.Collections.Generic;

namespace DatPhongDiWeb.Models.TypeOfRoom
{
    public class TypeofRoomView 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        public int PricePerNight { get; set; }
        public string Message { get; set; }
        public int Size { get; set; }
        public string ImagePath { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<ServiceView> ServiceViews { get; set; } 
        public List<TypeOfRoomServiceView> TypeOfRoomServiceViews { get; set; }
    }
}
