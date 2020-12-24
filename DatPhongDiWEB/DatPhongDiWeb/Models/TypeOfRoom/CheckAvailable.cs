using System;
using System.ComponentModel.DataAnnotations;

namespace DatPhongDiWeb.Models.TypeOfRoom
{
    public class CheckAvailable
    {
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
       //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }
        ///[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }
    }
}
