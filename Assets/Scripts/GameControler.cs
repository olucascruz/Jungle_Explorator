using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }


}
