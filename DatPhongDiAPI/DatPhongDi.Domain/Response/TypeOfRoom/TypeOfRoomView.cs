namespace DatPhongDi.Domain.Response.TypeOfRoom
{
    public class TypeOfRoomView : ResResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int AmountAdults { get; set; }
        public int AmountChild { get; set; }
        public int PricePerNight { get; set; }
        public int Size { get; set; }
        public string ImagePath { get; set; }
    }
}
