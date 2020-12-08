using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoomService;
using DatPhongDi.Domain.Response.TypeOfRoomService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class TypeOfRoomServiceService : ITypeOfRoomServiceService
    {
        private readonly ITypeOfRoomServiceRepository typeOfRoomServiceRepository;

        public TypeOfRoomServiceService(ITypeOfRoomServiceRepository typeOfRoomServiceRepository)
        {
            this.typeOfRoomServiceRepository = typeOfRoomServiceRepository;
        }

        public async Task<SaveTypeOfRoomServiceRes> Delete(int id)
        {
            return await typeOfRoomServiceRepository.Delete(id);
        }

        public async Task<TypeOfRoomServiceView> Get(int Id)
        {
            return await typeOfRoomServiceRepository.Get(Id);
        }

        public async Task<IEnumerable<TypeOfRoomServiceView>> Gets()
        {
            return await typeOfRoomServiceRepository.Gets();
        }

        public async Task<SaveTypeOfRoomServiceRes> Save(SaveTypeOfRoomServiceReq saveType)
        {
            return await typeOfRoomServiceRepository.Save(saveType);
        }
    }
}
