﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Response.Room
{
    public class RoomView
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int PricePerNight { get; set; }
        public int AmountAdult { get; set; }
        public int AmountChild { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int TypeOfRoomId { get; set; }
        public string TypeOfRoomName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreateDateStr { get; set; }
        public string ModifiedDateStr { get; set; }
    }
}