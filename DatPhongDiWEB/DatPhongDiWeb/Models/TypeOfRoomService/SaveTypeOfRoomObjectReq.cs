using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.TypeOfRoomService
{
    public class SaveTypeOfRoomObjectReq
    {
        public int Id { get; set; }
        public int[] ServiceId { get; set; }
        public int TypeOfRoomId { get; set; }
    }
}
