namespace DatPhongDi.Domain.Request.Image
{
    public class SaveImageReq
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public int TypeOfRoomId { get; set; }
    }
}
