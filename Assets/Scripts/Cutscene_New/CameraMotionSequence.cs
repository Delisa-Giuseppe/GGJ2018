using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[ExecuteInEditMode]
public class CameraMotionSequence : MonoBehaviour {

	public	string	sceneToLoad = "";

	[System.Serializable]
	public struct CameraMotion {
		public	float		TransitionTime;
		public	Transform	Destination;
	}

	public	List<CameraMotion>	Transforms		= new List<CameraMotion>();


	private	CameraMotion	currentFrame;
	private	int				currentFrameIdx		= 0;
	private new	Camera		camera				= null;

	void Start()
	{
		camera = Camera.main;
	}


	private IEnumerator CameraTransition()
	{
		Vector3 startPosition		= camera.transform.position;
		Quaternion startRotation	= camera.transform.rotation;

		float	currentTime = 0f;
		float	interpolant = 0f;

		while( interpolant < 1f )
		{
			currentTime += Time.deltaTime;
			interpolant = currentTime / currentFrame.TransitionTime;
			camera.transform.position = Vector3.Lerp ( startPosition, currentFrame.Destination.position, interpolant );
			camera.transform.rotation = Quaternion.Lerp( startRotation, currentFrame.Destination.rotation, interpolant );
			yield return null;
		}

		NextFrame();
	}



	public	void	NextFrame()
	{
		currentFrameIdx++;
		if ( currentFrameIdx == Transforms.Count )
		{
			OnEndSequence();
			return;
		}

		currentFrame = Transforms[ currentFrameIdx ];
		StartCoroutine( CameraTransition() );
	}
	


	public	void	Play()
	{
		currentFrame = Transforms[ currentFrameIdx ];
		StartCoroutine( CameraTransition() );
	}



	public void OnEndSequence()
	{
		SceneManager.LoadScene( sceneToLoad );
	}

}
