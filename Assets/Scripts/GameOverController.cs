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
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
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
