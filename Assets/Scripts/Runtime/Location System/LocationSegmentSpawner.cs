﻿using Zenject;
using UnityEngine;
using UnityEditor.UIElements;
using System.Collections.Generic;
using System;
using Unity.Collections;

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
        [SerializeField, ReadOnly]
        private readonly LocationSegmentPool locationSegmentPool;

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
        /// <param name="locationSegmentPool"></param>
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            //this.currentLocation = location;

            activeLocationSegments = new List<LocationSegment>(activeSegments);
            locationSegmentFactory = new LocationSegmentFactory(currentLocation, diContainer);
        }

        private void Start()
        {
            Preload();
            Spawn();
        }

        public void Preload()
        {
            activeLocationSegments = new List<LocationSegment>
            {
                locationSegmentFactory.Create(LocationSegmentType.Start_Segment, 6),
                locationSegmentFactory.Create(LocationSegmentType.Highway, 6),
                locationSegmentFactory.Create(LocationSegmentType.Highway, 6)
            };
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