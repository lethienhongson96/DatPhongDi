using System;
using System.ComponentModel.DataAnnotations;

namespace DatPhongDiWeb.Models.Room
{
    public class SaveRoomReq
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên phòng")]
        public int Name { get; set; }

        [Required]
        [Display(Name = "Giá phòng")]
        public int PricePerNight { get; set; }

        [Required]
        [Display(Name = "Số lượng người lớn")]
        public int AmountAdult { get; set; }

        [Required]
        [Display(Name = "Số lượng trẻ em")]
        public int AmountChild { get; set; }

        
        public int Status { get; set; }

        [Required]
        [Display(Name = "Trạng thái phòng")]
        public string StatusName { get; set; }

        public int TypeOfRoomId { get; set; }

        [Required]
        [Display(Name = "Loại phòng")]
        public string TypeOfRoomName { get; set; }
    }
}
