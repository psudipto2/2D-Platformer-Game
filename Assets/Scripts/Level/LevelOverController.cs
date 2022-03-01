using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject winCanvas;
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
        SoundManager.Instance.Play(Sounds.ButtonClicked);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level finished by the player");
            levelManager.MarkLevelComplete();
            winCanvas.SetActive(true);
        }
    }
    public void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClicked);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    public void quit()
    {
        SoundManager.Instance.Play(Sounds.ButtonClicked);
        Application.Quit();
    }
    public void LoadLobbby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClicked);
        SceneManager.LoadScene(0);
    }
}
