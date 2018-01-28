using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraMotionSequence : MonoBehaviour {

	public static CameraMotionSequence Instance = null;

	public	string		sceneToLoad		= "";
	public	Transform	Cube			= null;

	public	Transform	cameraStartTransform = null;
	public	Transform	cameraFinalTransform = null;

	[System.Serializable]
	public struct CubeMotion
	{
		public	float		TransitionTime;
		public	Vector3		CubeDestination;
	}

	public	List<CubeMotion>	Transforms		= new List<CubeMotion>();


	private	CubeMotion		currentFrame;
	private	int				currentFrameIdx		= 0;
	private new	Camera		camera				= null;

	void Start()
	{
		Instance = this;
		camera = Camera.main;
	}


	private IEnumerator CubeTransition()
	{
		Vector3 startCubeposition = Cube.position;
		float	currentTime = 0f;
		float	interpolant = 0f;
		
		while( interpolant < 1f )
		{
			currentTime += Time.deltaTime;
			interpolant = currentTime / currentFrame.TransitionTime;
			Cube.position = Vector3.Lerp( startCubeposition, currentFrame.CubeDestination, interpolant );
			yield return null;
		}

		NextFrame();
	}


	private IEnumerator CameraTransition()
	{
		Vector3 startPosition		= camera.transform.position;

		float	totalTime	= 0f;
		foreach( var a in Transforms ) totalTime += a.TransitionTime;
		float	currentTime = 0f;
		float	interpolant = 0f;

		while( interpolant < 1f )
		{
			currentTime += Time.deltaTime;
			interpolant = currentTime / totalTime;
			camera.transform.position = Vector3.Lerp ( cameraStartTransform.position, cameraFinalTransform.position, interpolant );
			yield return null;
		}
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
