using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Text timeText;
    private Text scoreText;

    private int score;

    void Awake()
    {
        timeText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();   
        scoreText = transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();   
    }

    // Use this for initialization
    void Start () 
    {

        score = 64000;
        scoreText.text = "Score: "+score+" Byte";
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            SetScore(Random.Range(-100, 101));
        }

	}

    public void SetScore(int number)
    {

        score += number;
        scoreText.text = "Score: " + score + " Byte";

    }


}
