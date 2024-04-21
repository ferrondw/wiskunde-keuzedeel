using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBookManager : MonoBehaviour
{
    public FlipBookState Jump;
    public FlipBookState Run;
    public FlipBookState Die;

    [SerializeField] private SpriteRenderer renderer;

    // hou me hier niet echt aan DRY, maar het is voor nu makkelijk zodat ik niet een state door hoef te geven aan de PlayerMovement
    public void SetJumpFrame(int frame)
    {
        if (frame > Jump.frames.Length || frame < 0) return;
        renderer.color = Jump.stateColor;
        renderer.sprite = Jump.frames[frame];
    }
    
    public void SetRunFrame(int frame)
    {
        if (frame > Run.frames.Length || frame < 0) return;
        renderer.color = Run.stateColor;
        renderer.sprite = Run.frames[frame];
    }
    
    public void SetDieFrame(int frame)
    {
        if (frame > Die.frames.Length || frame < 0) return;
        renderer.color = Die.stateColor;
        renderer.sprite = Die.frames[frame];
    }
}

[System.Serializable]
public struct FlipBookState
{
    public string name;
    public Sprite[] frames;
    public Color stateColor;
}