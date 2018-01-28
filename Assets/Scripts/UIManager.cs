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
		string CurrentTime = "";
		TransformTime( player.CurrentTime, ref CurrentTime );

		timeText.text = CurrentTime;
    }

    public void SetScore()
    {
        
        scoreText.text = "Score: " + player.Score + " Byte";

    }

	public	void	TransformTime( float fTime, ref string Time )
	{
		int iM = ( int ) ( ( fTime / 60f ) % 60f );
		int iS = ( int ) ( fTime % 60f );
		Time = iM.ToString( "00" ) + ":" + iS.ToString( "00" );
	}


}
