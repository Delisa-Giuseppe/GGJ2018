using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour {

	[Header("Ore, minuti, secondi")]
	public	Vector3			TempoLimite				= Vector3.zero;
	

	public	int				Score					= 65545;

	[ SerializeField ]
	public	float			Speed					= 1f;
	[ SerializeField ]
	public	float			m_Traslation			= 50f;
	[ SerializeField ]
	public	float			m_Accelleration			= 1f;
	[ SerializeField ]
	public	float			m_Decelleration			= 1f;

	private	float			limitTime				= 0;
	private	float			currentTime				= 0;
	private	float			m_LerpedTraslation		= 0f;

	private void Start()
	{
		limitTime = ( ( TempoLimite.x * 3600f ) + ( TempoLimite.y * 60f ) + TempoLimite.z );
	}

	// Update is called once per frame
	void Update ()
	{

		if ( Time.time > limitTime )
		{
			print( "Hai perso !!!" );
			enabled = false;
			return;
		}

		float currentTraslation = 0f;
		if ( Input.GetKey( KeyCode.A ) )
		{
			currentTraslation = m_Traslation;
		}

		if ( Input.GetKey( KeyCode.D ) )
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
		Vector3 centerPoint = hit.point - ( hit.normal * 1.5f );
		transform.RotateAround( centerPoint, transform.forward, m_LerpedTraslation * Time.deltaTime );

		// Move forward
		transform.position += transform.forward * ( Time.deltaTime * Speed );

	}

}
