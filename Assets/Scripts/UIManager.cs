using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Text timeText;
    private Text scoreText;
    private Player player;

    void Awake()
    {
        timeText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();   
        scoreText = transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Use this for initialization
    void Start () 
    {

        scoreText.text = "Score: "+player.Score+" Byte";
		
	}

    private void Update()
    {
        SetScore();
    }

    public void SetScore()
    {
        
        scoreText.text = "Score: " + player.Score + " Byte";

    }


}
