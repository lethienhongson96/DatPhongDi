using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.TypeOfRoom
{
    public class CheckAvailable
    {
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }
    }
}
