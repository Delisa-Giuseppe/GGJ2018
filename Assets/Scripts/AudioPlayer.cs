using UnityEngine;
using System.Collections.Generic;

public class AudioPlayer : MonoBehaviour {

	public	AudioClip	clip		= null;
	public	bool		loop		= false;

	private	AudioSource	Player = null;

	private void Start()
	{
		Player = gameObject.AddComponent<AudioSource>();
		Player.clip = clip;
		Player.loop = loop;
	}

	public	void	Play()
	{
		if ( clip == null )return;

		Player.Stop();
		Player.Play();

	}

}
