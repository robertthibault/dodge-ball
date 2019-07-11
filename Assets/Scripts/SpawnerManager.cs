using HoloToolkit.Examples.InteractiveElements;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private List<GameObject> Spawners = new List<GameObject>();
    private System.Random Rng = new System.Random();

    [Tooltip("The prefab to instanciate.")]
    public GameObject SpawnerPrefab;

    [Tooltip("The maximum number of spawners.")]
    public int MaxSpawnerCount = 5;

    public void PlaceSpawner()
    {
        Interactive addSpawnerButton = GameObject.Find("AddSpawnerButton").GetComponent<Interactive>();
        Interactive startGameButton = GameObject.Find("StartGameButton").GetComponent<Interactive>();

        if (Spawners.Count < MaxSpawnerCount)
        {
            GameObject placing = Instantiate(SpawnerPrefab);
            Spawners.Add(placing);
            startGameButton.IsEnabled = true;
        }
    }

    public void SetSpawnerManipulation(bool manipulable)
    {
        Spawners.ForEach(spwn => spwn.GetComponent<CapsuleCollider>().enabled = manipulable);
    }

    public GameObject GetRandomSpawner()
    {
        return Spawners[Rng.Next(Spawners.Count)];
    }
}
