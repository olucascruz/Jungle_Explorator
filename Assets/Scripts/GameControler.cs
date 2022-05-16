using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour

{
    public GameObject gameOver;
    public static GameControler instance;

    void Start()
    {
      instance = this;
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

}
