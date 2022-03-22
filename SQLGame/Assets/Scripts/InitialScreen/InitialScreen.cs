using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialScreen : MonoBehaviour
{
    public void continueGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void startNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
