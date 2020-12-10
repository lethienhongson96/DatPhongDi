using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.TypeOfRoom
{
    public class CheckAvailable
    {
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
