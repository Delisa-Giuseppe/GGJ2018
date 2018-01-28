using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damn;
    public float decreaseVelocity;
    public float speed;
    public float decreaseVelocityTime;
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
                if(decreaseVelocity > 0)
                {
                    StartCoroutine(DecreasePlayerVelocity(player));
                }
                player.Score -= damn;
            }

            if(this.tag == "Virus")
            {
                Destroy(this.gameObject);
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