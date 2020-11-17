using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IRoomRepository
    {
        Task<SaveRoomRes> Save(SaveRoomReq saveRoomReq);
    }
}
