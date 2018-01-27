using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public int numberEnemy;
    public float timerSpawn;
    public float enemyDistance; 
    public float enemySpeed;

    private float currentTimer;
    private GameObject enemyInstance;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {

        if(numberEnemy > 0)
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
                enemyInstance = Instantiate(enemy);
                enemyInstance.GetComponent<EnemyController>().Player = player;
                enemyInstance.GetComponent<EnemyController>().Speed = enemySpeed;
                enemyInstance.transform.position = player.transform.position + player.transform.forward * enemyDistance;
                enemyInstance.transform.rotation = player.transform.rotation;
            }
        }
	}
}
