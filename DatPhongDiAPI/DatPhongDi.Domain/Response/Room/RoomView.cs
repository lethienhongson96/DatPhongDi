using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Response.Room
{
    public class RoomView : ResResult
    {
        public int Id { get; set; }
        public int Name{ get; set; }      
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int TypeOfRoomId { get; set; }
        public string TypeOfRoomName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreateDateStr { get; set; }
        public string ModifiedDateStr { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
    }
}
