﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public int damn;
    public float decreaseVelocity;
    public float speed;
    public float decreaseVelocityTime;
    public GameObject particleEffect;

    protected bool playerTriggered;
    public AudioClip clip;

    /*public float timerSpawn;
    public float enemyDistance;
    public float enemySpeed;
    public int numberEnemy;
    public GameObject enemyPrefab;
    protected GameObject player;

    public abstract void Spawn();

    private void Awake()
    {
        player = GameObject.Find("Player");
        Spawn();
    }*/

    public virtual void MoveEnemy()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !playerTriggered)
        {
            if (particleEffect)
            {
                GameObject particle = Instantiate(particleEffect);
                particle.transform.position = other.transform.position;
            }

            playerTriggered = true;

            Player player = other.GetComponent<Player>();

            if(!player.immortal)
            {
                if(decreaseVelocity > 0)
                {
                    StartCoroutine(DecreasePlayerVelocity(player));
                }

                float score = player.Score - damn;
                if (score <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }

                player.Score -= damn;
            }

            GetComponent<AudioSource>().PlayOneShot(clip, 1f);

            foreach(var render in GetComponentsInChildren<MeshRenderer>())
            {
                render.enabled = false;
            }

            if (this.tag == "Virus")
            {
                Destroy(this.gameObject, 1f);
            }

        }
    }

    IEnumerator DecreasePlayerVelocity(Player player)
    {

        player.Speed -= decreaseVelocity;

        yield return new WaitForSeconds(decreaseVelocityTime);

        player.Speed += decreaseVelocity;
    }
}