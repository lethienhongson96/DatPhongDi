﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Response.TypeOfRoom
{
    public class CheckAvailable
    {
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
