﻿using Medic.AppModels.Diagnoses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class PatientInPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(EntryDate))]
        public DateTime EntryDate { get; set; }

        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }
    }
}