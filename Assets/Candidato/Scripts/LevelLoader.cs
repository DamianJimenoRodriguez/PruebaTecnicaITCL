using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevelByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevelByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;

        nextLevel = nextLevel >= SceneManager.sceneCountInBuildSettings ? 0 : nextLevel;
        SceneManager.LoadScene(nextLevel);
    }

    public void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}