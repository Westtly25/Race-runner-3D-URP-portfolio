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

    [SerializeField, Range(60f, 400f)]
    private float maxSpeed;
}

[Serializable]
public struct VisualTuningData
{
    private Color bodyColor;
    private Color accessoriesColor;
    private Color windowsColor;
}