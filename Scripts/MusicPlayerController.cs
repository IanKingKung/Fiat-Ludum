using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = songs[0];
        audioSource.Play();
    }

    
    void Update()
    {
        
    }
}
