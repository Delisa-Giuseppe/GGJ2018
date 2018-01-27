using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[ SerializeField ]
	public	float	m_Speed = 1f;
	[ SerializeField ]
	public	float	m_Traslation = 50f;
	[ SerializeField ]
	public	float	m_Accelleration = 1f;
	[ SerializeField ]
	public	float	m_Decelleration = 1f;


	private	float	m_LerpedTraslation = 0f;


	// Update is called once per frame
	void Update ()
	{
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
			return;
		}

		// rotate around cylinder center
		Vector3 centerPoint = hit.point - ( hit.normal * 1.5f );
		transform.RotateAround( centerPoint, transform.forward, m_LerpedTraslation * Time.deltaTime );

		// Move forward
		transform.position += transform.forward * ( Time.deltaTime * m_Speed );

	}
}
