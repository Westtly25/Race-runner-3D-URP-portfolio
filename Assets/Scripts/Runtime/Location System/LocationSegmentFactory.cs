using UniRx.Diagnostics;
using UnityEngine;
using Zenject;
using Logger = UniRx.Diagnostics.Logger;

namespace Assets.Scripts.Runtime.Location_System
{
    public class LocationSegmentFactory : IFactory<LocationSegmentType, LocationSegment>
    {
        private readonly DiContainer container;
        private readonly LocationSegment[] locationSegments;

        public LocationSegmentFactory(LocationConfig currentLocation, DiContainer container)
        {
            this.locationSegments = currentLocation.LocationSegments;
            this.container = container;
        }

        public LocationSegment Create(LocationSegmentType locationSegmentType)
        {
            for (int i = 0; i < locationSegments.Length; i++)
            {
                if (locationSegments[i].LocationSegmentType == locationSegmentType)
                {
                    return container.InstantiatePrefabForComponent<LocationSegment>(locationSegments[i]);
                }
            }

            return null;
        }

        public LocationSegment Create(LocationSegmentType locationSegmentType, byte lanesAmount)
        {
            for (int i = 0; i < locationSegments.Length; i++)
            {
                if (locationSegments[i].LocationSegmentType == locationSegmentType && 
                    locationSegments[i].LanesCount == lanesAmount)
                {
                    return container.InstantiatePrefabForComponent<LocationSegment>(locationSegments[i]);
                }
            }

            return null;
        }
    }
}