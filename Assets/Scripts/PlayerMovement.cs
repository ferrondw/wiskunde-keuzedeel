using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FlipBookManager flipBookManager;
    [SerializeField] private Text stateText;
    [SerializeField] private float runFPS;
    
    [Header("Jump Variables")]
    [SerializeField] private float gravity;
    [SerializeField] private float initialVelocity;

    [Header("Unity Events")]
    public UnityEvent onBeginJump;
    public UnityEvent onPeakJump;
    public UnityEvent onLandJump;
    [Space(20)]
    public UnityEvent onHit;
    public UnityEvent onDeath;
    

    private ParabolicFunction parabolicFunction;
    private State currentState = State.Grounded;
    private enum State
    {
        None,
        Airborne,
        Grounded
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // als je springt
        if (Input.GetKeyDown(KeyCode.Space) && currentState == State.Grounded)
        {
            StopAllCoroutines();
            Jump();
        }
        // als je runt
        else if (currentState == State.Grounded)
        {
            int runFrameIndex = (int)(Time.time * runFPS) % flipBookManager.Run.frames.Length;
            flipBookManager.SetRunFrame(runFrameIndex);
            
            stateText.color = flipBookManager.Run.stateColor;
            stateText.text = $"State: {currentState}\nAnimation State: {flipBookManager.Run.name} ({flipBookManager.Run.frames[runFrameIndex].name})";
        }
    }

    private void Die()
    {
        StopAllCoroutines();
        StartCoroutine(PerformDeath());
    }
    
    IEnumerator PerformDeath()
    {
        float startTime = Time.time;

        while (Time.time - startTime < 1.5f)
        {
            float elapsedTime = Time.time - startTime;

            float jumpProgress = elapsedTime / 1.5f;
            int jumpFrameIndex = Mathf.FloorToInt(jumpProgress * flipBookManager.Die.frames.Length);
            flipBookManager.SetDieFrame(jumpFrameIndex);

            stateText.color = flipBookManager.Die.stateColor;
            stateText.text = $"State: {currentState}\nAnimation State: {flipBookManager.Die.name} ({flipBookManager.Die.frames[jumpFrameIndex].name})";
            
            yield return null;
        }
        
        onDeath?.Invoke();
        currentState = State.None;
    }

    private void Jump()
    {
        // verander de player state 
        // currentState = State.Airborne;
        parabolicFunction = new ParabolicFunction(gravity, initialVelocity, transform.position.y);
        onBeginJump?.Invoke();
        
        // kijk hoe lang de jump duurt om naar zijn 2de nul punt te komen en start de jump met die info
        float totalTime = parabolicFunction.timeToZero();
        StartCoroutine(PerformJump(totalTime));
    }

    IEnumerator PerformJump(float totalTime)
    {
        // ik kan hier ook delta time gebruiken, maar dit is meer accurate
        float startTime = Time.time;
        bool reachedPeak = false; // super vies, maar met de helft van een float werken is echt super kut

        while (Time.time - startTime < totalTime)
        {
            float elapsedTime = Time.time - startTime;

            // hier bereken je hoe hoog je moet zijn met de parabolische functie en dan de positie van de player op die y-axis zetten
            float currentHeight = parabolicFunction.y(elapsedTime);
            transform.position = new Vector2(transform.position.x, currentHeight);

            // krijg het frame waar de player op moet zijn zodat de jump animatie perfect in de jump time past, niet heel efficiënt maar goed genoeg lol
            float jumpProgress = elapsedTime / totalTime;
            int jumpFrameIndex = Mathf.FloorToInt(jumpProgress * flipBookManager.Jump.frames.Length);
            flipBookManager.SetJumpFrame(jumpFrameIndex);

            // verander de stateText om alles netjes te laten zien, wederom niet efficiënt maar goed genoeg
            stateText.color = flipBookManager.Jump.stateColor;
            stateText.text = $"State: {currentState}\nAnimation State: {flipBookManager.Jump.name} ({flipBookManager.Jump.frames[jumpFrameIndex].name})\nJump Time: {totalTime} seconds";

            if (!reachedPeak && elapsedTime >= totalTime / 2)
            {
                onPeakJump?.Invoke();
                reachedPeak = true;
            }
            
            yield return null;
        }
        
        // om er zeker van te zijn dat ie niet een rare float afronding doet ofzo
        transform.position = new Vector2(transform.position.x, 0);
        onLandJump?.Invoke();
        currentState = State.Grounded;
    }
}