using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BallManager : MonoBehaviour
{

    public GameObject BallPrefab;
    public GameObject TimerText;
    public float ThrowingForce = 800f;
    public float SpawnInterval = 2f;
    public float BallLifetime = 5f;
    public int GameDuration = 60;

    public UnityEvent OnSpawningEndEvents;

    public void StartSpawning()
    {
        StartCoroutine(Spawning());
    }

    public void StopSpawning()
    {
        StopCoroutine(Spawning());
        StopAllCoroutines();
        OnSpawningEndEvents.Invoke();
    }

    private IEnumerator Spawning()
    {
        int time = 0;
        PlayerHitboxManager player = GameObject.Find("MixedRealityCamera").GetComponent<PlayerHitboxManager>();

        player.TimesHit = 0;
        player.HitboxActive = true;

        SpawnerManager spawners = gameObject.GetComponent<SpawnerManager>();
        TextMesh timerString = TimerText.GetComponent<TextMesh>();

        while (time <= GameDuration)
        {
            timerString.text = (GameDuration - time).ToString();

            GameObject spawner = spawners.GetRandomSpawner();
            GameObject newBall = Instantiate(BallPrefab, spawner.transform.position, Quaternion.identity);

            newBall.transform.LookAt(GameObject.Find("MixedRealityCamera").transform);
            newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * ThrowingForce);

            yield return new WaitForSeconds(SpawnInterval);

            Destroy(newBall, BallLifetime);
            time += (int)SpawnInterval;
        }
        OnSpawningEndEvents.Invoke();
        player.HitboxActive = false;
    }
}