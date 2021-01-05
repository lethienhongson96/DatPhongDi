using System;
using System.ComponentModel.DataAnnotations;

namespace DatPhongDiWeb.Models.Room
{
    public class SaveRoomReq
    {
        public int Id { get; set; }
       
        [Display(Name = "Tên phòng")]
        public int Name { get; set; }
        public int Status { get; set; }
        
        [Display(Name = "Trạng thái phòng")]
        public string StatusName { get; set; }

        public int TypeOfRoomId { get; set; }
        
        [Display(Name = "Loại phòng")]
        public string TypeOfRoomName { get; set; }
       
        public int Size { get; set; }        
        public string Description { get; set; }
    }
}
