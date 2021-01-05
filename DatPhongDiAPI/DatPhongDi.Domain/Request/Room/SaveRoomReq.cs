namespace DatPhongDi.Domain.Request.Room
{
    public class SaveRoomReq
    {
        public int Id { get; set; }
        public int Name{ get; set; }       
        public int Status { get; set; }
        public int TypeOfRoomId { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
    }
}
