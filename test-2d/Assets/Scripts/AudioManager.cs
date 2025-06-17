using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager instance;

	[SerializeField]
	private AudioSource BackgroundMusicSource;
	[SerializeField]
	private AudioSource WinGameSource;
	[SerializeField]
	private AudioSource LoseGameSource;
	
	public void PlayBackground()
	{
		BackgroundMusicSource.Play();
	}

	public void StopBackground()
	{
		BackgroundMusicSource.Stop();
	}

	public void PlayWin()
	{
		WinGameSource.Play();
	}

	public void PlayLose()
	{
		LoseGameSource.Play();
	}

	public static AudioManager Instance { get { return instance; } }

	private void Start()
	{
		instance = this;
	}

}
