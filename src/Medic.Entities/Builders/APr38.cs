﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class APr38
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<APr38>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Decision)
                    .WithOne(e => e.APr38s)
                    .HasForeignKey<APr38>(model => model.DecisionId);
            });
        }
    }
}