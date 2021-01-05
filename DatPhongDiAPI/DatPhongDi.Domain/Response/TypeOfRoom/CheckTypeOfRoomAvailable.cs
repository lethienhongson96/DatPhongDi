using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Response.TypeOfRoom
{
    public class CheckTypeOfRoomAvailableReq
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
