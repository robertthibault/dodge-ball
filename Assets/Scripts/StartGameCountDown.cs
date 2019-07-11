using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StartGameCountDown : MonoBehaviour
{

    public GameObject CountDownTextObject;
    public AudioClip CountDown3Sound;
    public AudioClip CountDown2Sound;
    public AudioClip CountDown1Sound;
    public AudioClip CountDownEndSound;
    private AudioSource AudioSource;

    public UnityEvent OnCountDownEndEvents;

    // Use this for initialization
    private void Start()
    {
        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.loop = false;
        AudioSource.volume = 1.0f;
        AudioSource.Stop();
    }

    public void StartCount()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        int time = 3;
        while (time >= 0)
        {
            switch (time)
            {
                case 0:
                    CountDownTextObject.GetComponent<TextMesh>().text = "GO!";
                    AudioSource.clip = CountDownEndSound;
                    AudioSource.Play();
                    break;
                case 1:
                    CountDownTextObject.GetComponent<TextMesh>().text = time.ToString();
                    AudioSource.clip = CountDown1Sound;
                    AudioSource.Play();
                    break;
                case 2:
                    CountDownTextObject.GetComponent<TextMesh>().text = time.ToString();
                    AudioSource.clip = CountDown2Sound;
                    AudioSource.Play();
                    break;
                case 3:
                    CountDownTextObject.GetComponent<TextMesh>().text = time.ToString();
                    AudioSource.clip = CountDown3Sound;
                    AudioSource.Play();
                    break;
            }
            yield return new WaitForSeconds(1f);
            time = time - 1;
        }
        OnCountDownEndEvents.Invoke();
        CountDownTextObject.GetComponent<TextMesh>().text = "Start";
    }
}
