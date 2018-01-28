using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public	static	UIManager Instance = null;

    private Text	timeText;
    private Text	scoreText;
	private	Image	countdownImage;
    private Player	player;

    void Awake()
    {
		Instance = this;

		timeText		= transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();   
        scoreText		= transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
		countdownImage	= transform.GetChild(0).transform.GetChild(2).GetComponent<Image>();
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

        timeText.text = "Time: "+CurrentTime;
    }

    public void SetScore()
    {
        
        scoreText.text = "Score: " + player.Score + " Byte";

    }

	public	void	SetCountDownImage( Sprite sprite )
	{
		countdownImage.enabled = true;
		if ( sprite == null )
		{
			countdownImage.enabled = false;
			return;
		}

		countdownImage.sprite = sprite;
	}

	public	void	TransformTime( float fTime, ref string Time )
	{
		int iM = ( int ) ( ( fTime / 60f ) % 60f );
		int iS = ( int ) ( fTime % 60f );
		Time = iM.ToString( "00" ) + ":" + iS.ToString( "00" );
	}


}
