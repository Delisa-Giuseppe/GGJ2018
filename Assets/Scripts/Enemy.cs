using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damn;
    public float decreaseVelocity;
    public float speed;
    public GameObject particleEffect;

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
                player.Score -= damn;
                player.Speed -= decreaseVelocity;
            }

            if(this.tag == "Virus")
            {
                Destroy(this.gameObject);
            }

        }
    }
}