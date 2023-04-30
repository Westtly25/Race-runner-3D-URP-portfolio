using System;
using UnityEngine;

namespace Assets.Scripts.Runtime.Location_System
{
    [Serializable]
    public class LocationConfig
    {
        [SerializeField, Range(0, 255)]
        private byte id;

        [SerializeField, TextArea(2, 4)]
        private string name;

        [SerializeField, TextArea(4, 10)]
        private string description;

        [SerializeField]
        private LocationSegment[] locationSegments;

        public LocationSegment[] LocationSegments => locationSegments;
    }
}
