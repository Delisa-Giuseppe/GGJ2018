using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;

    Rigidbody2D rigid;
    bool goUp;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(new Vector2(0, jumpForce));
        }

        if(!goUp)
            rigid.velocity = new Vector2(speed, 0);
        else
            rigid.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        goUp = !goUp;
        Destroy(collision.gameObject);
    }
}
