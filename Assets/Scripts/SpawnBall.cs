using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{

    public GameObject ball;
    public GameObject mainCamera;
    public float ballThrowingForce = 400f;
    public bool holdingBall = true;

    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        int time = 0;
        while (time <= 60)
        {
            float rand = Random.Range(-5, 5);
            GameObject clone = (GameObject)Instantiate(ball, new Vector3(rand, 2, rand), Quaternion.identity);
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * ballThrowingForce);
            yield return new WaitForSeconds(2f);
            Destroy(clone, 5f);
            time = time + 2;
        }
    }
}