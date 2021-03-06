﻿using Medic.Models.CP;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class ClinicHematologyPart
    {
        [XmlElement(ElementName = "Stage_Hemo")]
        public string StageHemo { get; set; }

        [XmlElement(ElementName = "Ongoing_Therapy")]
        public int OngoingTherapy { get; set; }

        [XmlElement(ElementName = "Evaluation")]
        public Evaluation Evaluation { get; set; }

        [XmlElement(ElementName = "Decision")]
        public Evaluation Decision { get; set; }
    }
}
