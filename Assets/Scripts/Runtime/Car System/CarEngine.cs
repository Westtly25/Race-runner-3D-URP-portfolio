using System;
using UnityEngine;

[Serializable]
public class CarEngine : ICarEngine
{
    [SerializeField, Range(50, 9999)]
    private ushort horsePower;
}