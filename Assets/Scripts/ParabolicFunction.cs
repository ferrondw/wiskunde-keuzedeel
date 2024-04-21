using UnityEngine; // nodig voor Mathf.Sqrt, wou eerst de functie zelf schrijven maar is voor nu niet echt nodig

public class ParabolicFunction // voorbeeld in desmos staat in "Sprites/parabool.png"
{
    public float Gravity { get; private set; }
    public float InitialVelocity { get; private set; }
    public float InitialHeight { get; private set; }

    public ParabolicFunction(float gravity, float initialVelocity, float initialHeight)
    {
        this.Gravity = gravity;
        this.InitialVelocity = initialVelocity;
        this.InitialHeight = initialHeight;
    }

    public float y(float t) // heb ook getY vervangen met gewoon y omdat het dan meer lijkt op een property dan een method, vind ik cleaner
    {
        // geen idee hoe dit werkt maar het werd uitgelegd in de les 🤷‍♂️
        return InitialHeight + (InitialVelocity * t) - (0.5f * Gravity * t * t);
    }

    public float timeToZero()
    {
        return (InitialVelocity + Mathf.Sqrt(InitialVelocity * InitialVelocity + 2 * Gravity * InitialHeight)) / Gravity;
    }
}