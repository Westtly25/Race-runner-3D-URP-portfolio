using System;
using UnityEngine;

[Serializable]
public class CarCharacteristics
{
    [SerializeField]
    private ushort Id;

    [SerializeField]
    private string Name;

    [SerializeField, Range(500f, 9999f)]
    private float mass;
}
