﻿using Medic.AppModels.UsedDrugs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IUsedDrugService
    {
        Task<List<UsedDrugCodeOption>> UsedDrugsByCodeAsync();
    }
}
