using UnityEngine;

public class Platform : MonoBehaviour
{
    private Transform player;
    private bool playerOnPlatform = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // kijk eerst ff hoe groot het platform is
        float minX = transform.position.x - transform.lossyScale.x / 2;
        float maxX = transform.position.x + transform.lossyScale.x / 2;

        float distanceY = player.position.y - transform.position.y;
        // dit duurde zo fk lang ik jank, ok dus als de player binnen het platform zijn X axis is
        // dan check je of de player wel net boven het platform is om te lopen
        if (player.position.x > minX && player.position.x < maxX && distanceY is < 2 and > 1.5f)
        {   
            // MAAR als de player al op het platform is, doe dan niks
            if (playerOnPlatform) return;
            
            // dan stop je de jump, zet je de player naar grounded en zeg je dat de player op het platform zit
            var playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.StopAllCoroutines();
            playerMovement.currentState = PlayerMovement.State.Grounded;
            playerOnPlatform = true;
        }
        // als je dus niet binnen zijn X axis bent en/of niet net erboven
        else
        {
            // dan check je eerst of je ver boven het platform bent (je hebt gejumped) dan ben je dus niet meer op het platform duhh
            if(distanceY > 2) playerOnPlatform = false;
            // beetje edge case, maar stel er is magisch ineens niets op het platform, return dan gewoon
            if (!playerOnPlatform) return;
            
            // als je niet heb gejumped maar ook niet meer op het platform zit betekend het dus dat je gewoon eraf valt, je jumped dus met een initial velocity van 0
            // oh en je zit niet meer op het platform :D
            player.GetComponent<PlayerMovement>().Jump(0);
            playerOnPlatform = false;
        }
    }
}