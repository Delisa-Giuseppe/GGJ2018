using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour {


	public	static Fader Instance			= null;

	public	Image		m_FadeImage			= null;
	public	float		m_TransitionTime	= 2f;



	private	float		Interpolant			= 0f;
	
	private	bool		m_InOverride		= false;
	private	bool		m_FadeInInternal	= false;


	// Use this for initialization
	void Start()
	{
		if ( Instance != null )
		{
			Destroy( gameObject );
			return;
		}
		Instance = this;
		DontDestroyOnLoad( this );
	}


	private IEnumerator Fade( bool fadeIn, System.Action callback = null )
	{
		Interpolant = 0f;
		float	currentTime = 0f;
		Color	startColor = m_FadeImage.color;
		while( Interpolant < 1f )
		{
			currentTime += Time.unscaledDeltaTime;
			Interpolant = currentTime / m_TransitionTime;
			float a = ( fadeIn == true ) ? m_FadeImage.color.a - Interpolant : m_FadeImage.color.a + Interpolant;
			m_FadeImage.color = new Color ( 0, 0, 0, a );
			yield return null;
		}
		Interpolant = 0f;

		print( fadeIn ? "Fadein:":"FadeOut" );

		if ( callback != null )
			callback();
	}


	public	void	FadeIn( System.Action callback = null )
	{
		StopAllCoroutines();
		StartCoroutine( Fade( fadeIn: true, callback: callback ) );
	}


	public	void	FadeOut( System.Action callback = null )
	{
		StopAllCoroutines();
		StartCoroutine( Fade( fadeIn: false, callback: callback ) );
	}
}
