using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour {

	public GameObject Cube = null;
	public string SceneToLoad = "";

	public void EnableCube()
	{
		Cube.SetActive( true );
	}

	public void	LoadGameScene()
	{
	//	Fader.Instance.FadeOut( () =>
			UnityEngine.SceneManagement.SceneManager.LoadScene( SceneToLoad );
	//	);
	}

}
