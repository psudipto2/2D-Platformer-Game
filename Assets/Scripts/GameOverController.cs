using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button Restrat;
    public Button Quit;
    public Button Lobby;
    private void Awake()
    {
        Restrat.onClick.AddListener(ReloadLevel);
        Quit.onClick.AddListener(quit);
        Lobby.onClick.AddListener(LoadLobbby);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
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
