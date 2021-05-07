using System;
using System.ComponentModel.DataAnnotations;

namespace DatPhongDiWeb.Views.TypeOfRoom
{
    public class CheckTypeOfRoomAvailable
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
