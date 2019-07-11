using UnityEngine;

public class PlayerHitboxManager : MonoBehaviour
{
    public AudioClip HitSound;
    private AudioSource HitAudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        HitAudioSource = gameObject.AddComponent<AudioSource>();
        HitAudioSource.clip = HitSound;
        HitAudioSource.loop = false;
        HitAudioSource.volume = 1.0f;
        HitAudioSource.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj + ", -1pv");
        HitAudioSource.clip = HitSound;
        HitAudioSource.Play();
    }
}