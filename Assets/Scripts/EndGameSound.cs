using UnityEngine;

public class EndGameSound : MonoBehaviour
{

    public AudioClip GameEndSound;

    private AudioSource AudioSource;

    public void Start()
    {
        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.loop = false;
        AudioSource.volume = 1.0f;
        AudioSource.Stop();
    }

    public void DoPlayEndGameSound()
    {
        AudioSource.clip = GameEndSound;
        AudioSource.Play();
    }
}
