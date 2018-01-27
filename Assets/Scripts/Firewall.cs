using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : Enemy 
{	

    private Vector3 direction;

    private void Awake()
    {
        int z = Random.Range(0, 2);
        if (z == 0)
            this.speed = -speed;
    }

    // Update is called once per frame
    void Update () 
    {

        MoveEnemy();
		
	}

    public override void MoveEnemy()
    {

        this.transform.Rotate(0, 0, this.speed * Time.deltaTime);

    }
}
