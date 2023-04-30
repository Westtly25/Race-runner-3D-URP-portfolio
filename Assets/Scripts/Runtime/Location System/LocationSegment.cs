using UnityEngine;

namespace Assets.Scripts.Runtime.Location_System
{
    public enum LocationSegmentType
    {
        Start_Segment,
        Highway,
        City_Road
    }

    public class LocationSegment : MonoBehaviour
    {
        [SerializeField]
        private int sizeX = 1;
        [SerializeField]
        private int sizeY = 1;
        [SerializeField]
        private int sizeZ = 1;

        [SerializeField]
        private LocationSegmentType locationSegmentType;

        [SerializeField, Range(2, 10)]
        private byte lanesCount;

        [SerializeField, Range(1f, 10f)]
        private float lanesOffset;

        [SerializeField]
        private Material material;

        [SerializeField]
        private Transform currentTransform;

        public int SizeX => sizeX;
        public int SizeY => sizeY;
        public int SizeZ => sizeZ;
        public LocationSegmentType LocationSegmentType => locationSegmentType;
        public byte LanesCount => lanesCount;
        public float LanesOffset => lanesOffset;
        public Material Material => material;
        public Transform CurrentTransform => currentTransform;

        private void Awake()
        {
            currentTransform = this.transform;
        }
    }
}