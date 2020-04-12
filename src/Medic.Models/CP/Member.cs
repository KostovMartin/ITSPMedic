﻿using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Member
    {
        [XmlElement(ElementName = "Spec")]
        public string Speciality { get; set; }

        [XmlElement(ElementName = "UIN")]
        public string UniqueIdentifier { get; set; }

        public string DoctorName { get; set; }
    }
}