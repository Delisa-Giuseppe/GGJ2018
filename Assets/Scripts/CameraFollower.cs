using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	[ SerializeField ]
	private	Transform		m_Target					= null;

	[ SerializeField ]
	private	Vector3			m_Offset					= Vector3.zero;

	Vector3 startRotation = Vector3.zero;

	private void Start()
	{
		startRotation = ( m_Target.position - transform.position );
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.Lerp( transform.position, m_Target.transform.position, Time.deltaTime * 8f );
		transform.position += transform.TransformDirection( m_Offset );


	}
}
