
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTrigger : MonoBehaviour {

	[ SerializeField ]
	private	Player	m_Player	= null;

	[ SerializeField ]
	private	string	m_SceneName	= "";

	// Use this for initialization
	void Start()
	{
		DontDestroyOnLoad( this );
	}

	// Async load of the next scene
	private	IEnumerator	SceneLoad()
	{

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync( m_SceneName );
		asyncLoad.allowSceneActivation = true;
		
		//Wait until the last operation fully loads to return anything
		while ( !asyncLoad.isDone )
		{
			yield return null;
		}

		Player player = FindObjectOfType<Player>();
		float startSpeed = player.Speed;
		player.Speed = 0f;
		Fader.Instance.FadeIn( () => { player.Speed = startSpeed; } );
	}


	private void OnTriggerEnter( Collider other )
	{
		if ( other.tag != "Player" )
			return;

		if ( m_Player == null )
		{
			print( "IL PLAYER DEVI INSERIRE, PIRLA!!!" );
			return;
		}
		m_Player.Speed = 0f;

		Fader.Instance.FadeOut( () => StartCoroutine( SceneLoad() ) );

		Destroy( GetComponent<Collider>() );	
	}



}
