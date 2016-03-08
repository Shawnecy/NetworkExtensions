﻿using System;
using System.Runtime.Serialization;
using Transit.Framework.Network;

namespace Transit.Addon.ToolsV2.Data
{
    public class TPPLaneDataSerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (typeName.Contains("Lane"))
                return typeof(TPPLaneData);
            if (typeName.Contains("VehicleType"))
                return typeof(ExtendedVehicleType);

            throw new SerializationException("Error on BindToType with type '" + typeName + "' and assembly '" + assemblyName + "'.");
        }
    }
}