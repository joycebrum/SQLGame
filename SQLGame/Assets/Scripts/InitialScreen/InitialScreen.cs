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

    public void startNewGameWithoutTutotial()
    {
        PlayerPrefs.DeleteAll();
        DeleteMessages();
        SetTutorialComplete();
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    private void DeleteMessages()
    {
        string path = Application.dataPath + "/VIDE/saves/VA";
        if (Directory.Exists(path)){
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
        
    }

    private void SetTutorialComplete()
    {
        PlayerPrefs.SetInt("firstStepTutorialComplete", 1);
        PlayerPrefs.SetInt("MessageTutorialComplete", 1);
        PlayerPrefs.SetInt("MessageTutorialComplete2", 1);
        PlayerPrefs.SetInt("CluesTutorialComplete", 1);
        PlayerPrefs.SetInt("DBTutorialComplete", 1);
        PlayerPrefs.SetInt("ShouldShowFriend", 0);
        PlayerPrefs.SetInt("Friend", 1);
        PlayerPrefs.SetInt("ShouldShowIAChat", 1);
        PlayerPrefs.SetInt("IAChat", 2);
        PlayerPrefs.SetInt("currentStageIndex", 1);
    }
}
