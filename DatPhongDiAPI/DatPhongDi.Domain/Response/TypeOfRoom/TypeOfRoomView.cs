﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Response.TypeOfRoom
{
    public class TypeOfRoomView
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
}