﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ProtocolDrugTherapy
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ProtocolDrugTherapy>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.ProtocolDrugTherapies)
                    .HasForeignKey(model => model.PatientId);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.ProtocolDrugTherapies)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.ProtocolDrugTherapies)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasOne(model => model.Diag)
                    .WithOne(d => d.ProtocolDrugTherapy)
                    .HasForeignKey<ProtocolDrugTherapy>(model => model.DiagId);

                b.HasOne(model => model.HematologyPart)
                    .WithOne(hp => hp.ProtocolDrugTherapy)
                    .HasForeignKey<ProtocolDrugTherapy>(model => model.HematologyPartId);

                b.HasOne(model => model.ChemotherapyPart)
                    .WithOne(cp => cp.ProtocolDrugTherapy)
                    .HasForeignKey<ProtocolDrugTherapy>(model => model.ChemotherapyPartId);

                b.HasMany(model => model.DrugProtocols)
                    .WithOne(dp => dp.ProtocolDrugTherapy)
                    .HasForeignKey(dp => dp.ProtocolDrugTherapyId);

                b.HasMany(model => model.AccompanyingDrugs)
                    .WithOne(ad => ad.ProtocolDrugTherapy)
                    .HasForeignKey(ad => ad.ProtocolDrugTherapyId);

                b.HasOne(model => model.Chairman)
                    .WithMany(hp => hp.ProtocolDrugTherapiesAsChairman)
                    .HasForeignKey(model => model.ChairmanId);

                b.HasMany(model => model.Members)
                    .WithOne(pdthp => pdthp.ProtocolDrugTherapy)
                    .HasForeignKey(pdthp => pdthp.ProtocolDrugTherapyId);
            });
        }
    }
}
