using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public UnityEvent onCollision;
    
    private Transform player;
    private void Start() => player = GameObject.FindGameObjectWithTag("Player").transform;
    
    private void Update()
    {
        // ik maak hier eigenlijk een soort bounding box voor de player, zodat ik niet built in components hoef te gebruiken want dat is grappig
        var distance = new Vector2(Mathf.Abs(transform.position.x - player.position.x), Mathf.Abs(transform.position.y - player.position.y));
        if (distance.x < 1 && distance.y < 2)
        {
            onCollision?.Invoke();
        }
    }
}