using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button Start;
    public GameObject LevelSelection;
    public GameObject button;
    private void Awake()
    {
        Start.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClicked);
        LevelSelection.SetActive(true);
        button.SetActive(false);
    }
}
