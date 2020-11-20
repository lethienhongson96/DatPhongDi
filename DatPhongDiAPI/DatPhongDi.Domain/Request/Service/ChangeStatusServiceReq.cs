using System;
using System.Collections.Generic;
using System.Text;

namespace DatPhongDi.Domain.Request.Service
{
    public class ChangeStatusServiceReq
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
