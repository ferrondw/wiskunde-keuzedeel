using System;

public class SineFunction
{
    public float Amplitude { get; private set; }
    public float Frequency { get; private set; }

    public SineFunction(float amplitude, float frequency)
    {
        Amplitude = amplitude;
        Frequency = frequency;
    }

    public float y(float x)
    {
        return Amplitude * (float)Math.Sin(2 * Math.PI * Frequency * x);
    }
}