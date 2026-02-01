using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; set;}
    AudioSource audioSource;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void ChangeMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    public void PlaySound(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
