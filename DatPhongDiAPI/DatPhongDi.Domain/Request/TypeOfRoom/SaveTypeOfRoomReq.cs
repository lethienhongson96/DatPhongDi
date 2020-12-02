namespace DatPhongDi.Domain.Request.TypeOfRoom
{
    public class SaveTypeOfRoomReq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status{ get; set; }
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        public int PricePerNight { get; set; }
    }
}
