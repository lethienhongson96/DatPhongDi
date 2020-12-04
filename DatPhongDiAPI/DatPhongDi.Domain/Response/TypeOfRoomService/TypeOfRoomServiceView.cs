using System.Collections.Generic;

namespace DatPhongDi.Domain.Response.TypeOfRoomService
{
    public class TypeOfRoomServiceView
    {
        public int Id { get; set; }
        public List<int> ServiceId { get; set; }
        public List<string> ServiceName { get; set; }
        public int TypeOfRoomId { get; set; }
        public string TypeOfRoomName { get; set; }
    }
}
