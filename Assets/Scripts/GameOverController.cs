using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button Restrat;
    public Button Quit;
    private void Awake()
    {
        Restrat.onClick.AddListener(ReloadLevel);
        Quit.onClick.AddListener(quit);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
