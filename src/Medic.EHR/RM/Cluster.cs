﻿using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Cluster : Item
    {
        [XmlElement(ElementName = Constants.StructureType)]
        [JsonProperty(Constants.StructureType)]
        public CS StructureType { get; set; }
        
        [XmlElement(ElementName = Constants.Parts)]
        [JsonProperty(Constants.Parts)]
        public List<Item> Parts { get; set; }
    }
}
