﻿using System.Collections;
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

    public bool             inputEnabled            = true;

    public bool             immortal                = false;

	private	float			limitTime				= 0;
	private	float			currentTime				= 0;
	private	float			m_LerpedTraslation		= 0f;

	private	bool			m_IsReady				= false;

	private IEnumerator Start()
	{
		float speed = Speed;
		limitTime = ( ( TempoLimite.x * 3600f ) + ( TempoLimite.y * 60f ) + TempoLimite.z );

		int	counter = 0;
		while ( counter < 3 )
		{
			counter += 1;
			// Show Counter
			print( "Game starts in " + counter );
			yield return new WaitForSecondsRealtime( 1f );
		}
		
		Speed = speed;
		m_IsReady = true;
	}


	// Update is called once per frame
	void Update ()
	{
		if ( m_IsReady == false )
			return;

		if ( Time.time > limitTime )
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
