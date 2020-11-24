﻿using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Status;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }
        public async Task<IEnumerable<StatusView>> GetStatusByTableId(int TableId)
        {
            return await statusRepository.GetStatusByTableId(TableId);
        }
    }
}
