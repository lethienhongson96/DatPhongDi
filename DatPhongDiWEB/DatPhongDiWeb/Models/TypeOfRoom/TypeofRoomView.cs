﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.TypeOfRoom
{
    public class TypeofRoomView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
}