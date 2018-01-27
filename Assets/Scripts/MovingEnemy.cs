using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    private float currentTimer;
    private GameObject enemyInstance;
    private bool exists;

    public override void Spawn()
    {
        exists = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(exists)
        {
            if (numberEnemy > 0)
            {
                if (currentTimer < timerSpawn)
                {
                    currentTimer += Time.deltaTime;
                }
                else
                {
                    numberEnemy--;

                    if (enemyInstance)
                        Destroy(enemyInstance);

                    currentTimer = 0;
                    enemyInstance = Instantiate(enemyPrefab);
                    enemyInstance.GetComponent<EnemyController>().Speed = enemySpeed;
                    enemyInstance.GetComponent<EnemyController>().Player = player;
                    enemyInstance.transform.position = player.transform.position + player.transform.forward * enemyDistance;
                    enemyInstance.transform.rotation = player.transform.rotation;
                }
            }
        }
    }
}
