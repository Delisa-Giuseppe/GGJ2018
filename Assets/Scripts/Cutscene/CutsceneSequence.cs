using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameEvent      : UnityEngine.Events.UnityEvent { }

public class CutsceneSequence : MonoBehaviour {

	public	CutsceneFrame[]	m_Frames				= null;
	public	GameEvent		m_OnSequnceFinished		= null;

	private	CutsceneFrame	m_CurrentFrame			= null;
	private	int				m_currentFrameIdx		= 0;

	IEnumerator Waiter()
	{
		yield return new WaitForSecondsRealtime( m_CurrentFrame.Duration );

		Fader.Instance.FadeOut( () => NextFrame() );
	}

	//////////////////////////////////////////////////////////////////////////
	// Play
	public	void	Play()
	{
		m_CurrentFrame = m_Frames[ m_currentFrameIdx ];

		// Show UI Item tht show frames

		Fader.Instance.FadeIn();

		StartCoroutine( Waiter() );
	}


	//////////////////////////////////////////////////////////////////////////
	// NextFrame
	public	void	NextFrame()
	{
		m_currentFrameIdx++;
		m_CurrentFrame = m_Frames[ m_currentFrameIdx ];

		Fader.Instance.FadeIn();
		StartCoroutine( Waiter() );
	}

}
