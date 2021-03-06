﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Transfer
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Transfer>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstPatientTransfer)
                    .HasForeignKey<Transfer>(model => model.FirstMainDiagId);

                b.HasIndex(model => model.FirstMainDiagId).IsUnique(false);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondPatientTransfer)
                    .HasForeignKey<Transfer>(model => model.SecondMainDiagId);

                b.HasIndex(model => model.SecondMainDiagId).IsUnique(false);

                b.HasIndex(model => model.HospitalPracticeId).IsUnique(false);

                b.HasIndex(model => model.CPFileId).IsUnique(false);

                b.Property(model => model.DischargeWard).HasMaxLength(5);

                b.Property(model => model.TransferWard).HasMaxLength(5);

                b.Property(model => model.AmbulatoryProcedure).HasMaxLength(4);
            });
        }
    }
}
