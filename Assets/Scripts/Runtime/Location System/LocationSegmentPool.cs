using System;
using UnityEngine;
using UniRx.Toolkit;

namespace Assets.Scripts.Runtime.Location_System
{
    public class LocationSegmentPool : AsyncObjectPool<LocationSegment>
    {
        private readonly LocationSegment locationSegment;
        private readonly Transform hierarchyParent;

        public LocationSegmentPool(LocationSegment locationSegment, Transform hierarchyParent)
        {
            this.locationSegment = locationSegment;
            this.hierarchyParent = hierarchyParent;
        }

        protected override IObservable<LocationSegment> CreateInstanceAsync()
        {
            throw new NotImplementedException();
        }
    }
}