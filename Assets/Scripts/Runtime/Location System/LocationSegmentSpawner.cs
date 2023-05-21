using System;
using Zenject;
using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Runtime.Location_System
{
    [Serializable]
    public class LocationSegmentSpawner : MonoBehaviour
    {
        [Header("INJECTED DATA & SERVICES")]
        [SerializeField, ReadOnly]
        private LocationConfig currentLocation;
        [SerializeField, ReadOnly]
        private LocationSegmentFactory locationSegmentFactory;

        private byte preloadSegments = 3;
        private byte activeSegments = 3;
        [SerializeField]
        private List<LocationSegment> activeLocationSegments;

        /// <summary>
        /// Inject data by Zenject
        /// Get Level Config from Adressables
        /// </summary>
        /// <param name="location"></param>
        /// <param name="locationSegmentFactory"></param>
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            //this.currentLocation = location;

            activeLocationSegments = new List<LocationSegment>(activeSegments);
            //locationSegmentFactory = new LocationSegmentFactory(currentLocation);
        }

        private void Start()
        {
            Preload();
            Spawn();
        }

        public void Preload()
        {
            
        }

        public void Spawn()
        {
            Vector3 startSpawPosition = Vector3.zero;

            for (int i = 0; i < activeLocationSegments.Count; i++)
            {
                activeLocationSegments[i].CurrentTransform.position = startSpawPosition;
                startSpawPosition += new Vector3(0, 0, activeLocationSegments[i].SizeZ);
            }
        }

        public void Despawn()
        {

        }
    }
}