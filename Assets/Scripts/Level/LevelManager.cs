using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string level;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelStatus(level)==LevelStatus.Locked)
        {
            setLevelStatus(level, LevelStatus.Unlocked);
        }
    }
    public void MarkLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        setLevelStatus(currentScene.name, LevelStatus.Completed);
        int nextSceneIndex = currentScene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneAt(nextSceneIndex);
        setLevelStatus(nextScene.name, LevelStatus.Unlocked);
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus= (LevelStatus)PlayerPrefs.GetInt(level);
        return levelStatus;
    }
    public void setLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
