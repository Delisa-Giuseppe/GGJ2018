using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public	float	speed = 1f;
	public	float	traslation = 50f;
	public	float	accelleration = 1f;
	public	float	decelleration = 1f;

	private	float	lerpedTraslation = 0f;

	// Update is called once per frame
	void Update ()
	{
		float currentTraslation = 0f;
		if ( Input.GetKey( KeyCode.A ) )
		{
			currentTraslation = traslation;
		}

		if ( Input.GetKey( KeyCode.D ) )
		{
			currentTraslation = -traslation;
		}


		lerpedTraslation = Mathf.Lerp
		( 
			lerpedTraslation, 
			currentTraslation,  
			( currentTraslation != 0f ? accelleration : decelleration ) * Time.deltaTime
		);


		RaycastHit hit;
		if( Physics.Raycast( transform.position, -transform.up, out hit ) == false )
		{
			print( "Porca madonna" );
			return;
		}

		// rotate around cylinder center
		Vector3 centerPoint = hit.point - ( hit.normal * 1.5f );
		transform.RotateAround( centerPoint, transform.forward, lerpedTraslation * Time.deltaTime );

		// Move forward
		transform.position += transform.forward * ( Time.deltaTime * speed );

	}
}
