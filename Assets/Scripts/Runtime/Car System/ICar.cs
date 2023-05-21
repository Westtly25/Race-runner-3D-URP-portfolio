public interface ICar
{
    CarCharacteristics Characteristics { get; }

    VisualTuningData TuningData { get; }

    CarWheel[] CarWheels { get; }
}