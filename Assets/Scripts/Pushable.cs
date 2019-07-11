using UnityEngine;

public class Pushable : MonoBehaviour
{
    public void Push()
    {
        Rigidbody rbdy = gameObject.GetComponent<Rigidbody>();
        rbdy.isKinematic = false;

        gameObject.transform.LookAt(GameObject.Find("MixedRealityCamera").transform);
        gameObject.transform.rotation = Quaternion.Inverse(gameObject.transform.rotation);

        rbdy.AddForce(gameObject.transform.forward * 200f);
    }
}
