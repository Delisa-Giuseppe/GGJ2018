using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour {

	public static Player Instance = null;

	[Header("Ore, minuti, secondi")]
    public	Vector2			TempoLimite				= Vector2.zero;
	public	int				Score					= 65545;
	public	float			CurrentTime				= 0;
	public	Sprite[]		CountdownFrames			= null;

	[ SerializeField ]
	public	float			Speed					= 1f;
	[ SerializeField ]
	public	float			m_Traslation			= 50f;
	[ SerializeField ]
	public	float			m_Accelleration			= 1f;
	[ SerializeField ]
	public	float			m_Decelleration			= 1f;

    public bool             inputEnabled            = true;

    public bool             immortal                = false;

	private	float			limitTime				= 0;
	private	float			m_LerpedTraslation		= 0f;

	private	bool			m_IsReady				= false;

	private void Awake()
	{
		Instance = this;
	}

	private IEnumerator Start()
	{
		Fader fader						= FindObjectOfType<Fader>();
		EndSceneTrigger endSceneTrigger = FindObjectOfType<EndSceneTrigger>();
		if ( fader == null || endSceneTrigger == null )
		{
			print( "Player::You need to include \"Fader\" prefab and \"EndSceneTrigger\" prefabs in scene!!" );
			print( "Remember to set references by dragging requeste objects in these components." );
			enabled = false;
			yield break;
		}

		endSceneTrigger.m_Player = this;

		///////////////////////////////////////////////////////////////////////////

		float speed = Speed;
        CurrentTime = ( ( TempoLimite.x * 60f ) + TempoLimite.y );

		int	counter = 3;
		UIManager.Instance.SetCountDownImage( CountdownFrames[ 3 - counter ] );

		while ( counter > 0 )
		{
			// Show Counter
			UIManager.Instance.SetCountDownImage( CountdownFrames[ 3 - counter ] );
			print( "Game starts in " + ( counter-- ) );
			yield return new WaitForSecondsRealtime( 1f );
		}
		UIManager.Instance.SetCountDownImage( null );

		Speed = speed;
		m_IsReady = true;
	}


	// Update is called once per frame
	void Update ()
	{
		if ( m_IsReady == false )
			return;

        CurrentTime -= Time.deltaTime;

		if ( CurrentTime <= 0f )
		{
			print( "Hai perso !!!" );
			enabled = false;
			return;
		}

		float currentTraslation = 0f;
        if ( Input.GetKey( KeyCode.A ) && inputEnabled)
		{
			currentTraslation = m_Traslation;
		}

        if ( Input.GetKey( KeyCode.D ) && inputEnabled)
		{
			currentTraslation = -m_Traslation;
		}


		m_LerpedTraslation = Mathf.Lerp
		( 
			m_LerpedTraslation, 
			currentTraslation,  
			( currentTraslation != 0f ? m_Accelleration : m_Decelleration ) * Time.deltaTime
		);


		RaycastHit hit;
		if( Physics.Raycast( transform.position, -transform.up, out hit ) == false )
		{
			print( "Player::Update:Player cannot retrieve normals from foots !!" );
			enabled = false;
			return;
		}

		// rotate around cylinder center
		Vector3 centerPoint = hit.point - ( hit.normal * 1f );
		transform.RotateAround( centerPoint, transform.forward, m_LerpedTraslation * Time.deltaTime );

		// Move forward
		transform.position += transform.forward * ( Time.deltaTime * Speed );

	}

}
