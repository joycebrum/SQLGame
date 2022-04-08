using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        DeleteMessages();
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    private void DeleteMessages()
    {
        string path = Application.dataPath + "/VIDE/saves/VA";
        var files = Directory.GetFiles(path);

        foreach(var file in files){
            File.Delete(file);
        }
        print("deletou");
    }
}
