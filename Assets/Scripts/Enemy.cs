using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damn;
    public float decreaseVelocity;
    public float speed;

    protected bool playerTriggered;

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

    protected void OnTriggerEnter(Collider other)
    {

        print("Gesucristo");

        if(other.tag == "Player" && !playerTriggered)
        {
            other.GetComponent<Player>().Score -= damn;
            other.GetComponent<Player>().Speed -= decreaseVelocity;
        }
    }

}