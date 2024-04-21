using UnityEngine;

public class SineMovement : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.4f;
    [SerializeField] private float frequency = 1f;

    private Vector3 startPos;
    private SineFunction sineFunction;

    private void Start()
    {
        startPos = transform.position;
        sineFunction = new SineFunction(amplitude, frequency);
    }

    private void Update()
    {
        float yOffset = sineFunction.y(Time.time);
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}