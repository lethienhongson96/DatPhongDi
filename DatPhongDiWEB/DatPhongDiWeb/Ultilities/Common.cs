﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Ultilities
{
    public static class Common
    {
        public static string apiUrl = @"https://localhost:44362/api";

        public enum Table
        {
            TypeOfRoom = 1,
            Room = 2,
            Booking = 3,
            Service = 4
        }
    }
}
