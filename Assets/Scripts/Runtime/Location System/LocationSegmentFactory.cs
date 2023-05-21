using Zenject;
using UnityEngine;
using Assets.Code.Scripts.Runtime.Assets_Management;

namespace Assets.Scripts.Runtime.Location_System
{
    public class LocationSegmentFactory
    {
        private readonly LocationSegment[] locationSegments;
        private readonly AssetProvider assetProvider;

        public LocationSegmentFactory(LocationConfig currentLocation, AssetProvider assetProvider)
        {
            this.locationSegments = currentLocation.LocationSegments;
            this.assetProvider = assetProvider;
        }

        //public LocationSegment Create(LocationSegmentType locationSegmentType)
        //{
        //    for (int i = 0; i < locationSegments.Length; i++)
        //    {
        //        if (locationSegments[i].LocationSegmentType == locationSegmentType)
        //        {

        //            return container.InstantiatePrefabForComponent<LocationSegment>(locationSegments[i]);
        //        }
        //    }

        //    return null;
        //}

        //public LocationSegment Create(LocationSegmentType locationSegmentType, byte lanesAmount)
        //{
        //    for (int i = 0; i < locationSegments.Length; i++)
        //    {
        //        if (locationSegments[i].LocationSegmentType == locationSegmentType && 
        //            locationSegments[i].LanesCount == lanesAmount)
        //        {
        //            return container.InstantiatePrefabForComponent<LocationSegment>(locationSegments[i]);
        //        }
        //    }

        //    return null;
        //}
    }
}