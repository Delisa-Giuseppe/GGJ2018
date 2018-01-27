using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	public	float			Smoothness					= 2.5f;

	[ SerializeField ]
	private	Transform		m_Target					= null;

	[ SerializeField ]
	private	Vector3			m_Offset					= Vector3.zero;

	// Update is called once per frame
	void LateUpdate ()
	{
		if ( m_Target == null )
			return;

		if ( Smoothness < 0.0f )
			Smoothness = 0f;
		
		// Position
		transform.position = Vector3.Lerp
		(
			transform.position,
			m_Target.TransformPoint( m_Offset ),
			Time.deltaTime * Smoothness
		);

		// Rotation
		transform.rotation = Quaternion.Slerp
		(
			transform.rotation,
			Quaternion.LookRotation( m_Target.position - transform.position , m_Target.up ),
			Time.deltaTime * Smoothness
		);

	}

}
