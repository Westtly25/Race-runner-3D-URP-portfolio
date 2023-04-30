using System;
using UnityEngine;

[Serializable]
public class Car : MonoBehaviour, ICar
{
    [SerializeField]
    private CarCharacteristics characteristics;

    [SerializeField]
    private VisualTuningData tuningData;

    [SerializeField]
    private CarWheel[] carWheels = new CarWheel[4];

    public CarCharacteristics Characteristics => characteristics;

    public VisualTuningData TuningData => tuningData;

    public CarWheel[] CarWheels => carWheels;
}