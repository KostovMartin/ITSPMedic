﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Procedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Procedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Implant)
                    .WithOne(i => i.Procedure)
                    .HasForeignKey<Procedure>(model => model.ImplantId);

                b.Property(model => model.ACHICode).HasMaxLength(12);

                b.Property(model => model.HLNumber).HasMaxLength(12);

                b.Property(model => model.SendAPr).HasMaxLength(12);

                b.Property(model => model.InAPr).HasMaxLength(12);
            });
        }
    }
}