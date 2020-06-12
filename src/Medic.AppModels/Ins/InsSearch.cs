﻿using Medic.AppModels.Contracts;
using Medic.AppModels.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class InsSearch : IQueryStringBuilder
    {
        [Display(Name = nameof(SendDiagnose))]
        public string SendDiagnose { get; set; }

        [Display(Name = nameof(CountOfAdditionalDiagnoses))]
        public int? CountOfAdditionalDiagnoses { get; set; }

        [Display(Name = nameof(Sex))]
        public int? Sex { get; set; }

        [Display(Name = nameof(HealthRegion))]
        public int? HealthRegion { get; set; }

        [Display(Name = nameof(Age))]
        public int? Age { get; set; }

        [Display(Name = nameof(OlderThan))]
        public int? OlderThan { get; set; }

        [Display(Name = nameof(YoungerThan))]
        public int? YoungerThan { get; set; }

        [Display(Name = nameof(Order))]
        public InOrderEnum Order { get; set; }

        [Display(Name = nameof(Direction))]
        public OrderDirectionEnum Direction { get; set; }

        [Display(Name = nameof(Length))]
        public PageLengthEnum Length { get; set; } = PageLengthEnum.SmallLength;

        public Dictionary<string, string> BuildQuery(string prefix)
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(SendDiagnose))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(SendDiagnose)}", SendDiagnose);
            }

            if (CountOfAdditionalDiagnoses != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(CountOfAdditionalDiagnoses)}", CountOfAdditionalDiagnoses.ToString());
            }

            if (Sex != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(Sex)}", Sex.ToString());
            }

            if (HealthRegion != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(HealthRegion)}", HealthRegion.ToString());
            }

            if (Age != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(Age)}", Age.ToString());
            }

            if (OlderThan != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(OlderThan)}", OlderThan.ToString());
            }

            if (YoungerThan != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(YoungerThan)}", YoungerThan.ToString());
            }

            queryString.Add(nameof(Order), ((int)Order).ToString());
            queryString.Add(nameof(Direction), ((int)Direction).ToString());
            queryString.Add(nameof(Length), ((int)Length).ToString());

            return queryString;
        }

        public override string ToString()
        {
            return $"{nameof(SendDiagnose)}:{SendDiagnose}&{nameof(CountOfAdditionalDiagnoses)}:{CountOfAdditionalDiagnoses}&{nameof(Sex)}:{Sex}" +
                $"&{nameof(HealthRegion)}:{HealthRegion}&{nameof(Age)}:{Age}&{nameof(OlderThan)}:{OlderThan}&{nameof(YoungerThan)}:{YoungerThan}" + 
                $"&{nameof(Order)}:{(int)Order}&{nameof(Direction)}:{(int)Direction}&{nameof(Length)}:{(int)Length}";
        }
    }
}
