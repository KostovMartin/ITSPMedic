﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Practice
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Practice>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.HealthRegion)
                    .WithOne(hr => hr.Practice)
                    .HasForeignKey<Practice>(model => model.HealthRegionId);

                b.HasIndex(model => model.HealthRegionId).IsUnique(false);

                b.Property(model => model.Number).HasMaxLength(12);

                b.Property(model => model.Code).HasMaxLength(12);

                b.Property(model => model.Name).HasMaxLength(250);

                b.Property(model => model.Address).HasMaxLength(250);

                b.Property(model => model.NZOKCode).HasMaxLength(10);
            });
        }
    }
}