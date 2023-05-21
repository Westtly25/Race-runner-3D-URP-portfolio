using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Runtime.Location_System
{
    [CreateAssetMenu(fileName = "New Location Config", menuName = "Project / Locations / Location Config", order = 1)]
    public class LocationConfig : ScriptableObject
    {
        [SerializeField, Range(0, 255)]
        private byte id;

        [SerializeField, TextArea(2, 4)]
        private string name;

        [SerializeField, TextArea(4, 10)]
        private string description;

        [SerializeField]
        private AssetReference[] references;

        [SerializeField]
        private LocationSegment[] locationSegments;

        public LocationSegment[] LocationSegments => locationSegments;
    }
}
