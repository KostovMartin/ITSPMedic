﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class PathProcedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<PathProcedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.PathProcedures)
                    .HasForeignKey(model => model.PatientId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.PathProcedures)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(pr => pr.PathProcedures)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasIndex(model => model.PatientHRegionId).IsUnique(false);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.PathProcedures)
                    .HasForeignKey(model => model.SenderId);

                b.HasIndex(model => model.SenderId).IsUnique(false);

                b.HasOne(model => model.CeasedProcedure)
                    .WithOne(ccp => ccp.PathProcedure)
                    .HasForeignKey<PathProcedure>(model => model.CeasedProcedureId);

                b.HasIndex(model => model.CeasedProcedureId).IsUnique(false);

                b.HasOne(model => model.CeasedClinicalPath)
                    .WithOne(ccp => ccp.PathProcedurePath)
                    .HasForeignKey<PathProcedure>(model => model.CeasedClinicalPathId);

                b.HasIndex(model => model.CeasedClinicalPathId).IsUnique(false);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstPathProcedure)
                    .HasForeignKey<PathProcedure>(model => model.FirstMainDiagId);

                b.HasIndex(model => model.FirstMainDiagId).IsUnique(false);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondPathProcedure)
                    .HasForeignKey<PathProcedure>(model => model.SecondMainDiagId);

                b.HasIndex(model => model.SecondMainDiagId).IsUnique(false);

                b.HasMany(model => model.DoneNewProcedures)
                    .WithOne(p => p.PathProcedure)
                    .HasForeignKey(p => p.PathProcedureId);

                b.HasOne(model => model.UsedDrug)
                    .WithOne(ud => ud.PathProcedure)
                    .HasForeignKey<PathProcedure>(model => model.UsedDrugId);

                b.HasIndex(model => model.UsedDrugId).IsUnique(false);

                b.HasMany(model => model.ClinicProcedures)
                    .WithOne(cp => cp.PathProcedure)
                    .HasForeignKey(cp => cp.PathProcedureId);

                b.HasMany(model => model.DoneProcedures)
                    .WithOne(dp => dp.PathProcedure)
                    .HasForeignKey(dp => dp.PathProcedureId);

                b.HasIndex(model => model.HospitalPracticeId).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.IZNumChild).HasMaxLength(12);

                b.Property(model => model.VisitDocumentUniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.VisitDocumentName).HasMaxLength(100);

                b.Property(model => model.OutUniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.APrPriem).HasColumnType("decimal(15,4)");

                b.Property(model => model.APrSend).HasColumnType("decimal(15,4)");

                b.Property(model => model.AllDoneCost).HasColumnType("decimal(15,4)");

                b.Property(model => model.AllDoneProcedures).HasColumnType("decimal(15,4)");

                b.Property(model => model.MedicalWard).HasColumnType("decimal(15,4)");
            });
        }
    }
}