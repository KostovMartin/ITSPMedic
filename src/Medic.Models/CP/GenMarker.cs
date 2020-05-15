﻿using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class GenMarker
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Sign")]
        public int Sign { get; set; }
    }
}
