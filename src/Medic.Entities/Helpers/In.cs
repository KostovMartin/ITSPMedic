﻿using AutoMapper;
using Medic.AppModels.Ins;
using System.Linq;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class In
    {
        public In Copy()
        {
            return base.Copy<In>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<In, CP.In>()
                .ForMember(i => i.PatientBranch, config => config.MapFrom(i => i.PatientBranch == default && i.PatientBranch.HealthRegion == default ? default : i.PatientBranch.HealthRegion.Code))
                .ForMember(i => i.PatientHRegion, config => config.MapFrom(i => i.PatientHRegion == default ? default : i.PatientHRegion.Code))
                .ForMember(i => i.SendDateAsString, config => config.Ignore())
                .ForMember(i => i.ExaminationDateAsString, config => config.Ignore())
                .ForMember(i => i.PlannedEntryDateAsString, config => config.Ignore())
                .ForMember(i => i.EntryDateAsString, config => config.Ignore());

            expression.CreateMap<CP.In, In>()
                .ForMember(i => i.PatientBranch, config => config.MapFrom(i => new PatientBranch() { HealthRegion = new HealthRegion() { Code = i.PatientBranch } }))
                .ForMember(i => i.PatientBranchId, config => config.Ignore())
                .ForMember(i => i.PatientHRegion, config => config.MapFrom(i => new HealthRegion() { Code = i.PatientHRegion }))
                .ForMember(i => i.PatientHRegionId, config => config.Ignore())
                .ForMember(i => i.CPFile, config => config.Ignore())
                .ForMember(i => i.CPFileId, config => config.Ignore())
                .ForMember(i => i.PatientId, config => config.Ignore())
                .ForMember(i => i.SenderId, config => config.Ignore())
                .ForMember(i => i.Id, config => config.Ignore());

            expression.CreateMap<In, PatientInPreviewViewModel>();

            expression.CreateMap<In, InPreviewViewModel>()
                .ForMember(pvm => pvm.PatientId, config => config.MapFrom(i => i.Patient.Id));

            expression.CreateMap<In, InViewModel>()
                .ForMember(ivm => ivm.PatientBranch, config => config.MapFrom(i => i.PatientBranch != default && i.PatientBranch.HealthRegion != default ? i.PatientBranch.HealthRegion.Name : default))
                .ForMember(ivm => ivm.PatientHRegion, config => config.MapFrom(i => i.PatientHRegion != default ? i.PatientHRegion.Name : default))
                .ForMember(ivm => ivm.CPFile, config => config.MapFrom(i => i.CPFile != default && i.CPFile.FileType != default ? i.CPFile.FileType.Name : default));
        }
    }
}
