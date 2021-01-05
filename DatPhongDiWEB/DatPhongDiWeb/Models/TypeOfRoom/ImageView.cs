using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.TypeOfRoom
{
    public class ImageView
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public int TypeOfRoomId { get; set; }
    }
}
