using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decompteur : MonoBehaviour {

    public GameObject decompteurText;
    public AudioClip soundDecompte3;
    public AudioClip soundDecompte2;
    public AudioClip soundDecompte1;
    public AudioClip soundGo;
    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = 1.0f;
        audioSource.Stop();
        StartCoroutine(decompte());
    }

    IEnumerator decompte()
    {
        int time = 3;
        while (time >= 0)
        {            
            switch (time)
            {
                case 0:
                    decompteurText.GetComponent<TextMesh>().text = "GO!";
                    audioSource.clip = soundGo;
                    audioSource.Play();
                    break;
                case 1:
                    decompteurText.GetComponent<TextMesh>().text = time.ToString();
                    audioSource.clip = soundDecompte1;
                    audioSource.Play();
                    break;
                case 2:
                    decompteurText.GetComponent<TextMesh>().text = time.ToString();
                    audioSource.clip = soundDecompte2;
                    audioSource.Play();
                    break;
                case 3:
                    decompteurText.GetComponent<TextMesh>().text = time.ToString();
                    audioSource.clip = soundDecompte3;
                    audioSource.Play();
                    break;
            }
            yield return new WaitForSeconds(1f);
            time = time - 1;
        }
    }
}
