﻿using Medic.AppModels.CPFiles;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class CPFileService : ICPFileService
    {
        private readonly MedicContext MedicContext;

        public CPFileService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }
        
        public async Task<List<CPFileSummaryViewModel>> GetSummaryAsync()
        {
            return await GetSummary();
        }

        public async Task<List<CPFileSummaryViewModel>> GetSummaryByMonthAsync()
        {
            List<CPFileSummaryViewModel> summaries = await GetSummary();
            HashSet<CPFileSummaryViewModel> summariesByDate = new HashSet<CPFileSummaryViewModel>(new SummaryByMonthComaprer());
            CPFileSummaryViewModel current;

            if (summaries != default && summaries.Count > 0)
            {
                foreach (CPFileSummaryViewModel model in summaries)
                {
                    if (summariesByDate.TryGetValue(model, out current))
                    {
                        current.InsCount += model.InsCount;
                        current.OutsCount += model.OutsCount;
                        current.PatientTransfersCount += model.PatientTransfersCount;
                        current.PlannedProceduresCount += model.PlannedProceduresCount;
                        current.ProtocolDrugTherapiesCount += model.ProtocolDrugTherapiesCount;
                    }
                    else
                    {
                        current = new CPFileSummaryViewModel()
                        {
                            DateFrom = new DateTime(model.DateFrom.Year, model.DateFrom.Month, 1),
                            InsCount = model.InsCount,
                            OutsCount = model.OutsCount,
                            PatientTransfersCount = model.PatientTransfersCount,
                            PlannedProceduresCount = model.PlannedProceduresCount,
                            ProtocolDrugTherapiesCount = model.ProtocolDrugTherapiesCount
                        };

                        summariesByDate.Add(current);
                    }
                }
            }

            return summariesByDate.ToList();
        }

        private async Task<List<CPFileSummaryViewModel>> GetSummary()
        {
            return await MedicContext.CPFiles
                .Select(cp => new CPFileSummaryViewModel()
                {
                    DateFrom = cp.DateFrom,
                    InsCount = cp.Ins.Count,
                    OutsCount = cp.Outs.Count,
                    PatientTransfersCount = cp.PatientTransfers.Count,
                    PlannedProceduresCount = cp.PlannedProcedures.Count,
                    ProtocolDrugTherapiesCount = cp.ProtocolDrugTherapies.Count
                })
                .OrderBy(cp => cp.DateFrom)
                .ToListAsync();
        }

        private class SummaryByMonthComaprer : IEqualityComparer<CPFileSummaryViewModel>
        {
            public bool Equals(CPFileSummaryViewModel x, CPFileSummaryViewModel y)
            {
                if (x == default)
                {
                    throw new ArgumentNullException(nameof(x));
                }

                if (y == default)
                {
                    throw new ArgumentNullException(nameof(y));
                }

                return x.DateFrom.Month == y.DateFrom.Month && x.DateFrom.Year == y.DateFrom.Year;
            }

            public int GetHashCode(CPFileSummaryViewModel obj)
            {
                if (obj == default || obj.DateFrom == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }

                return ($"{obj.DateFrom.Month}-{obj.DateFrom.Year}").GetHashCode();
            }
        }
    }
}