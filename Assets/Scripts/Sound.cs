using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{

	public static Sound sound;
	public AudioSource[] Source;
	public AudioClip[] Clip;
	public AudioListener Listener;
	public AudioSource SourceMusic;
	public AudioClip MusicClip;

    private void Awake()
    {
		if (sound == null)
		{
			sound = this;
			GameObject.DontDestroyOnLoad(gameObject);
			Listener = gameObject.GetComponent<AudioListener>();
			SourceMusic = gameObject.AddComponent<AudioSource>();
			SourceMusic.playOnAwake = false;
			Source = new AudioSource[10];
			Clip = new AudioClip[10];

			for (int i = 0; i < 10; i++)
			{
				Source[i] = gameObject.AddComponent<AudioSource>();
				Source[i].playOnAwake = false;
			}
			PlayMusic();
			
		}
	}


    public void Start()
	{	

	}
	
	public void PlaySound (string Type)
	{
		Debug.Log("! PlaySound " + Type);
		for (int i=0; i < 10; i++)
		{
			if (!Source[i].isPlaying)
			{
				Debug.Log("PlaySound "+ Type);
				Clip[i] = Resources.Load("Sounds/"+Type) as AudioClip; 
				Source[i].clip = Clip[i]; 
				Source[i].Play();
				return;
			}			
		}
	}

	public void PlayMusic()
	{
		if(SourceMusic.isPlaying) return;
		MusicClip = Resources.Load("Sounds/Music0") as AudioClip;
		SourceMusic.clip = MusicClip;
		SourceMusic.Play();
	}		


	public void SetMusicVolume(float volume) 
	{
		SourceMusic.volume = volume;
		PlayerPrefs.SetFloat("MusicVolum", volume);
	}

	public void SetSoundVolume(float volume)
	{
		PlayerPrefs.SetFloat("SoundVolum", volume);
		for (int i = 0; i < 10; i++)
		{
			Source[i].volume = volume;
		}
	}
}
