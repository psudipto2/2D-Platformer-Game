using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    LevelManager levelManager;
    GameObject gameObject;
    public Button Restrat;
    public Button Quit;
    public Button Lobby;
    public Button NextLevel;
    private void Awake()
    {
        Restrat.onClick.AddListener(ReloadLevel);
        Quit.onClick.AddListener(quit);
        Lobby.onClick.AddListener(LoadLobbby);
        NextLevel.onClick.AddListener(nextLevel);
    }

    private void nextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level finished by the player");
            levelManager.MarkLevelComplete();
            gameObject.SetActive(true);
        }
    }
    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void LoadLobbby()
    {
        SceneManager.LoadScene(0);
    }
}
