using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Request.TypeOfRoom
{
    public class SaveTypeOfRoomReq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status{ get; set; }
    }
}
