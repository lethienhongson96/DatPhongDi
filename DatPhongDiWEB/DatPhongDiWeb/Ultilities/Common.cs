using System;
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
            Course = 1,
            Module = 2,
            Teacher = 3,
            Student = 4
        }
    }
}
