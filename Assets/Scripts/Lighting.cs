using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{

    private bool playerTriggered;
    public int inputDisabledTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !playerTriggered)
        {

            playerTriggered = true;

            Player player = other.GetComponent<Player>();

            if(!player.immortal)
            {
                StartCoroutine(SetPlayerinput(player));
            }

        }
    }

    IEnumerator SetPlayerinput(Player player)
    {
        
        player.inputEnabled = false;

        yield return new WaitForSeconds(inputDisabledTime);

        player.inputEnabled = true;

    }

}
