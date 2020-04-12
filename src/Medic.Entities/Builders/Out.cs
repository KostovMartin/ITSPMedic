﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Out
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Out>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.Outs)
                    .HasForeignKey(model => model.PatientId);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.Outs)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.Outs)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.Outs)
                    .HasForeignKey(model => model.SenderId);

                b.HasOne(model => model.SendDiagnose)
                    .WithOne(d => d.SendOut)
                    .HasForeignKey<Out>(model => model.SendDiagnoseId);

                b.HasMany(model => model.Diagnoses)
                    .WithOne(d => d.Out)
                    .HasForeignKey(d => d.OutId);

                b.HasOne(model => model.Dead)
                    .WithOne(d => d.OutDead)
                    .HasForeignKey<Out>(model => model.DeadId);

                b.HasOne(model => model.OutMainDiagnose)
                    .WithOne(d => d.OutMain)
                    .HasForeignKey<Out>(main => main.OutMainDiagnoseId);

                b.HasMany(model => model.OutDiagnoses)
                    .WithOne(d => d.OutOut)
                    .HasForeignKey(d => d.OutOutId);

                b.HasMany(model => model.Procedures)
                    .WithOne(p => p.Out)
                    .HasForeignKey(p => p.OutId);

                b.HasOne(model => model.HistologicalResult)
                    .WithOne(hr => hr.Out)
                    .HasForeignKey<Out>(model => model.HistologicalResultId);

                b.HasOne(model => model.Epicrisis)
                    .WithOne(e => e.Out)
                    .HasForeignKey<Out>(model => model.EpicrisisId);

                b.HasOne(model => model.UsedDrug)
                    .WithOne(ud => ud.Out)
                    .HasForeignKey<Out>(model => model.UsedDrugId);
            });
        }
    }
}