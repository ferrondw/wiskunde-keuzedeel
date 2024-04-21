public class QuadraticalFunction
{ 
    public float a { get; private set; }
    public float b { get; private set; }
    public float c { get; private set; }
    
    public QuadraticalFunction(float a, float b, float c)
    { 
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public float y(float x)
    {
        // haakjes zijn niet nodig maar maakt het wat makkelijker om te lezen
        return (this.a * x * x) + (this.b * x) * x;
    }
}