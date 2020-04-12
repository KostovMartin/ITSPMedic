﻿using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Choise
    /// </summary>
    [Serializable]
    public partial class Choise : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }
        
        public int Number { get; set; }

        public int Checked { get; set; }

        public string Text { get; set; }

        public int? EvaluationId { get; set; }

        public Evaluation Evaluation { get; set; }
    }
}