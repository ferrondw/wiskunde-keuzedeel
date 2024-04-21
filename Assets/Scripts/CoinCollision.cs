using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollision : MonoBehaviour
{
    public Transform player;
    public Vector2 playerScale;
    public UnityEvent onCoinCollected;

    private void Start()
    {
        onCoinCollected.AddListener(CollectCoin);
    }

    private void Update()
    {
        // ik maak hier eigenlijk een soort bounding box voor de player, zodat ik niet built in components hoef te gebruiken want dat is grappig
        var distance = new Vector2(Mathf.Abs(transform.position.x - player.position.x), Mathf.Abs(transform.position.y - player.position.y));
        if (distance.x < playerScale.x && distance.y < playerScale.y)
        {
            onCoinCollected?.Invoke();
        }
    }

    private void CollectCoin()
    {
        Debug.Log("Coin collected!");
        Destroy(gameObject);
    }
}