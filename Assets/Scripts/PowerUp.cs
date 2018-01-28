﻿using System.Collections;
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
    public int validTime;
    public float speedUp;
    public int scoreUp;
    public GameObject particleEffect;
    public AudioClip clip;

    bool playerTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !playerTriggered)
        {
            GetComponent<AudioSource>().PlayOneShot(clip, 1);

            if(particleEffect)
            {
                GameObject particle = Instantiate(particleEffect);
                particle.transform.position = other.transform.position;
            }                

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

            this.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    public IEnumerator ActiveImmortality(Player player)
    {
        player.immortal = true;

        yield return new WaitForSeconds(validTime);

        player.immortal = false;

        Destroy(this.gameObject);

    }

    public IEnumerator ActiveSpeedUp(Player player)
    {
        player.Speed += speedUp;

        yield return new WaitForSeconds(validTime);

        player.Speed -= speedUp;

        Destroy(this.gameObject);
    }

    public IEnumerator ActiveScoreUp(Player player)
    {

        player.Score += scoreUp;

        yield return null;

        Destroy(this.gameObject);

    }



}
