using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject hitbox;
    public AudioClip brakeSound;
    private AudioSource brakeAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        brakeAudioSource = gameObject.AddComponent<AudioSource>();
        brakeAudioSource.clip = brakeSound;
        brakeAudioSource.loop = false;
        brakeAudioSource.volume = 1.0f;
        brakeAudioSource.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj + ", -1pv");
        brakeAudioSource.clip = brakeSound;
        brakeAudioSource.Play();
    }
}