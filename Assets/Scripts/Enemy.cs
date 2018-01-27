using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damn;
    public float decreaseVelocity;
    public float speed;

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
}