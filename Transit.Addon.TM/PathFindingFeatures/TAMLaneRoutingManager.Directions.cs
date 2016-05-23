﻿using System.Collections.Generic;
using System.Linq;
using Transit.Addon.TM.Data;
using Transit.Framework;
using UnityEngine;

namespace Transit.Addon.TM.PathFindingFeatures
{
    public partial class TAMLaneRoutingManager
    {
        private TAMLaneRoute TransformToRoute(uint laneId, TAMLaneDirection directions)
        {
            if (directions == TAMLaneDirection.None)
            {
                return null;
            }

            var nodeId = NetManager.instance.FindLaneNodeId(laneId);
            if (nodeId == null)
            {
                return null;
            }

            var connections = NetManager.instance.GetConnectingLanes(laneId, (NetLane.Flags)directions).ToArray();
            if (!connections.Any())
            {
                return null;
            }

            return new TAMLaneRoute()
            {
                LaneId = laneId,
                NodeId = nodeId.Value,
                Connections = connections.ToArray()
            };
        }

        private TAMLaneDirection GetRelativeDirection(Vector3 source, Vector3 destination)
        {
            if (Vector3.Angle(source, destination) > 150f)
            {
                return TAMLaneDirection.Forward;
            }
            else
            {
                if (Vector3.Dot(Vector3.Cross(source, -destination), Vector3.up) > 0f)
                {
                    return TAMLaneDirection.Right;
                }
                else
                {
                    return TAMLaneDirection.Left;
                }
            }
        }

        private TAMLaneDirection GetRouteDirection(uint sourceLaneId, uint destinationLaneId, ushort nodeId)
        {
            var sourceLane = NetManager.instance.m_lanes.m_buffer[sourceLaneId];
            var sourceSegmentId = sourceLane.m_segment;
            var sourceSegment = NetManager.instance.m_segments.m_buffer[sourceSegmentId];
            var sourceSegmentDirection = sourceSegment.GetDirection(nodeId);

            var destinationLane = NetManager.instance.m_lanes.m_buffer[destinationLaneId];
            var destinationSegmentId = destinationLane.m_segment;
            var destinationSegment = NetManager.instance.m_segments.m_buffer[destinationSegmentId];
            var destinationSegmentDirection = destinationSegment.GetDirection(nodeId);

            return GetRelativeDirection(sourceSegmentDirection, destinationSegmentDirection);
        }

        public bool ToggleLaneDirection(uint laneId, TAMLaneDirection flags)
        {
            //if (!MayHaveLaneDirection(laneId))
            //{
            //    RemoveLaneDirection(laneId);
            //    return false;
            //}

            //TAMLaneDirection? arrows = _laneDirections[laneId];
            //if (arrows == null)
            //{
            //    // read currently defined arrows
            //    uint laneFlags = (uint)Singleton<NetManager>.instance.m_lanes.m_buffer[laneId].m_flags;
            //    laneFlags &= Flags.lfr; // filter arrows
            //    arrows = (TAMLaneDirection)laneFlags;
            //}

            //arrows ^= flags;
            //_laneDirections[laneId] = arrows;
            //ApplyLaneDirection(laneId, false);
            return true;
        }

        //public void RemoveLaneDirection(uint laneId)
        //{
        //    if (laneId <= 0)
        //        return;

        //    _laneDirections[laneId] = null;
        //    uint laneFlags = (uint)Singleton<NetManager>.instance.m_lanes.m_buffer[laneId].m_flags;

        //    if (((NetLane.Flags)laneFlags & NetLane.Flags.Created) == NetLane.Flags.None)
        //    {
        //        Singleton<NetManager>.instance.m_lanes.m_buffer[laneId].m_flags = 0;
        //    }
        //    else
        //    {
        //        Singleton<NetManager>.instance.m_lanes.m_buffer[laneId].m_flags &= (ushort)~Flags.lfr;
        //    }
        //}

        public void ScrubSegment(uint segmentId)
        {
            //uint laneId = NetManager.instance.m_segments.m_buffer[segmentId].m_lanes;
            //while (laneId != 0)
            //{
            //    if (!ApplyLaneDirection(laneId))
            //    {
            //        RemoveLaneDirection(laneId);
            //    }
            //    laneId = NetManager.instance.m_lanes.m_buffer[laneId].m_nextLane;
            //}
        }
    }
}