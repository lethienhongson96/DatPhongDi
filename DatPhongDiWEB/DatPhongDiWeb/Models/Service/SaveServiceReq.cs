using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Models.Service
{
    public class SaveServiceReq
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên dịch vụ")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Hình ảnh")]
        public string Icon { get; set; }
        [Required]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
    }
}
