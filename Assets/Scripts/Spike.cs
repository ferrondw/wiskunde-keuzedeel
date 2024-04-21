using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public void OnCollision()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Die();
    }
}
