﻿using Medic.AppModels.Patients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPatientService
    {
        Task<PatientViewModel> GetPatientAsync(int id);

        Task<List<PatientPreviewViewModel>> GetPatientsByQueryAsync(PatientSearch patientSearch, int startIndex, int length);

        Task<int> GetPatientsCountAsync(PatientSearch search);
    }
}