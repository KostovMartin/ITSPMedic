﻿using Medic.App.Models.Bases;
using Medic.AppModels.Diags;
using System.Collections.Generic;

namespace Medic.App.Models.Home
{
    public class HomePageDiagModel : BasePageModel
    {
        public List<DiagMKBSummaryViewModel> DiagMKBSummaryViewModels { get; set; }
    }
}
