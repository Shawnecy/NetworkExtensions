using System.Collections.Generic;
using Transit.Addon.TM.Traffic;

namespace Transit.Addon.TM.TrafficLight
{
    class CustomSegment
    {
        public ushort Node1 = 0;
        public ushort Node2 = 0;

        public CustomSegmentLights Node1Lights;
        public CustomSegmentLights Node2Lights;
    }
}
