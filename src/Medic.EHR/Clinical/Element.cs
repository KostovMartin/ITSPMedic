﻿using Medic.EHR.Clinical.Base;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives.Base;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Element<T> : Item<T>
    {
        [XmlElement(ElementName = Constants.Value)]
        public EHRDataValue<T> Value { get; set; }
    }
}
