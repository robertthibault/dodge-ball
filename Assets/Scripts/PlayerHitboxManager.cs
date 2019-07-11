using UnityEngine;

public class PlayerHitboxManager : MonoBehaviour
{
    public AudioClip HitSound;
    private AudioSource HitAudioSource;

    public int TimesHit { get; set; }
    public bool HitboxActive { get; set; }

    private void Start()
    {
        HitAudioSource = gameObject.AddComponent<AudioSource>();
        HitAudioSource.clip = HitSound;
        HitAudioSource.loop = false;
        HitAudioSource.volume = 1.0f;
        HitAudioSource.Stop();

        TimesHit = 0;
        HitboxActive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!HitboxActive) { return; }

        GameObject otherObj = collision.gameObject;

        HitAudioSource.clip = HitSound;
        HitAudioSource.Play();

        TimesHit++;
    }
}