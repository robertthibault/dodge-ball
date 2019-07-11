using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private List<GameObject> PreGameMenu = new List<GameObject>();

    private void Start()
    {
        PreGameMenu.Add(GameObject.Find("StartGameButton"));
        PreGameMenu.Add(GameObject.Find("AddSpawnerButton"));
    }

    public void SetPreGameMenuVisibility(bool visibility)
    {
        PreGameMenu.ForEach(btn => btn.SetActive(visibility));
    }
}
