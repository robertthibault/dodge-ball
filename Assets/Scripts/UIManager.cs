using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public GameObject StartMenuButton;
    //public GameObject SpawnerButton;
    //public GameObject GameTimerButton;
    //public GameObject ScoreText;

    private List<GameObject> PreGameMenu = new List<GameObject>();
    private List<GameObject> GameMenu = new List<GameObject>();
    private List<GameObject> PostGameMenu = new List<GameObject>();

    private void Start()
    {
        PreGameMenu.Add(GameObject.Find("StartGameButton"));
        PreGameMenu.Add(GameObject.Find("AddSpawnerButton"));
        PreGameMenu.Add(GameObject.Find("RemoveSpawnersButton"));
        PreGameMenu.Add(GameObject.Find("QuitGameButton"));

        GameMenu.Add(GameObject.Find("GameTimerButton"));

        PostGameMenu.Add(GameObject.Find("ScoreText"));

        GameMenu.ForEach(elem => elem.SetActive(false));
        PostGameMenu.ForEach(elem => elem.SetActive(false));
    }

    public void SetPreGameMenuVisibility(bool visibility)
    {
        PreGameMenu.ForEach(elem => elem.SetActive(visibility));
    }

    public void SetGameMenuVisibility(bool visibility)
    {
        GameMenu.ForEach(elem => elem.SetActive(visibility));
    }

    public void SetPostGameMenuVisibility(bool visibility)
    {
        SetGameMenuVisibility(!visibility);
        SetPreGameMenuVisibility(visibility);

        GameObject scoreText = PostGameMenu[0];
        int timesHit = GameObject.Find("MixedRealityCamera").GetComponent<PlayerHitboxManager>().TimesHit;

        scoreText.GetComponent<TextMesh>().text = timesHit + " hits";

        PostGameMenu.ForEach(elem => elem.SetActive(visibility));
    }
}
