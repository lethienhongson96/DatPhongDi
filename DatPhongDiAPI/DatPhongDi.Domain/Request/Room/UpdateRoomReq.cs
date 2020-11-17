namespace DatPhongDi.Domain.Request.Room
{
    public class UpdateRoomReq
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int PricePerNight { get; set; }
        public int AmountAdult  { get; set; }
        public int AmountChild { get; set; }
        public int Status { get; set; }
        public int TypeOfRoomId { get; set; }

    }
}
