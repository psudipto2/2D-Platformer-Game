using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button Start;
    private void Awake()
    {
        Start.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
