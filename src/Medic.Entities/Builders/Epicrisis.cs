﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Epicrisis
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Epicrisis>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}
