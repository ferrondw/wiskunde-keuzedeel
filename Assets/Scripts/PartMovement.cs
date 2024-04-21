using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMovement : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x - Time.deltaTime * 8, transform.position.y);
    }
}
