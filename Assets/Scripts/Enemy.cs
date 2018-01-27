using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float timerSpawn;
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
    }
}