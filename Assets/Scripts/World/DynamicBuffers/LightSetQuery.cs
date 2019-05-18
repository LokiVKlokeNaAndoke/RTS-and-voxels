﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using Unity.Mathematics;

namespace Scripts.World.DynamicBuffers
{
    public enum SetLightType : byte
    {
        Sunlight = 0,
        RegularLight = 1,
    }

    public enum PropagationType : byte
    {
        Propagate = 2,
        Depropagate = 1,
        Regular = 0,
    }

    [InternalBufferCapacity(0)]
    public struct LightSetQueryData : IBufferElementData
    {
        public int3 Pos;
        public byte NewLight;
        public SetLightType LightType;
        public PropagationType Propagation;
    }
}