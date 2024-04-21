using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnCollision()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().GetCoin(); // moet het zo doen omdat de method niet static kan zijn
        Destroy(gameObject);
    }
}
