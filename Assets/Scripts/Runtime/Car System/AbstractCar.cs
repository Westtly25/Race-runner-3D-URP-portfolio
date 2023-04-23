using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AbstractCar : MonoBehaviour, ICar
{
    [SerializeField]
    private CarCharacteristics characteristics;

    [SerializeField]
    private ICarEngine carEngine;

    [SerializeField]
    private CarWheel[] carWheels = new CarWheel[4];

    public CarCharacteristics Characteristics => characteristics;
    public ICarEngine CarEngine => carEngine;
}
