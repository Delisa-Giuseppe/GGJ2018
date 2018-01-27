using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	
    public enum PowerUpType
    {
        IMMORTAL,
        SCORE_UP,
        SPEED_UP
    }

    public PowerUpType powerUpType;
    public bool playerTriggered;
    public float validTime;
    public float speedUp;
    public int scoreUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !playerTriggered)
        {
            playerTriggered = true;
            Player player = other.GetComponent<Player>();

            switch(powerUpType)
            {
                case PowerUpType.IMMORTAL:
                    StartCoroutine(ActiveImmortality(player));
                break;
                case PowerUpType.SPEED_UP:
                    StartCoroutine(ActiveSpeedUp(player));
                break;
                case PowerUpType.SCORE_UP:
                    StartCoroutine(ActiveScoreUp(player));
                break;
            }
        }
    }

    IEnumerator ActiveImmortality(Player player)
    {
        player.immortal = true;

        yield return new WaitForSeconds(validTime);

        player.immortal = false;
    }

    IEnumerator ActiveSpeedUp(Player player)
    {
        player.Speed += speedUp;

        yield return new WaitForSeconds(validTime);

        player.Speed -= speedUp;
    }

    IEnumerator ActiveScoreUp(Player player)
    {

        player.Score += scoreUp;

        yield return null;

    }

}
