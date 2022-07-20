using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialScreen : MonoBehaviour
{

    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject sandboxButtons;
    public void continueGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void startNewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("IsSandBoxMode", 0);
        StartGame();
    }

    public void startNewGameWithoutTutotial()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("IsSandBoxMode", 0);
        SetTutorialComplete();
        StartGame();
    }

    private void StartGame()
    {
        DeleteMessages();
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void OpenSandboxMenu()
    {
        menuButtons.SetActive(false);
        sandboxButtons.SetActive(true);
    }

    public void CloseSandboxMenu()
    {
        menuButtons.SetActive(true);
        sandboxButtons.SetActive(false);
    }

    private void DeleteMessages()
    {
        string path = (Application.platform == RuntimePlatform.OSXPlayer ? Application.persistentDataPath : Application.dataPath) + "/VIDE/saves/VA";
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
        PlayerPrefs.SetInt("hasNewMessages", 1);
    }

    public void TutorialSandbox()
    {

    }

    private void startSandbox(StagesType stageType)
    {
        PlayerPrefs.SetInt("IsSandBoxMode", 1);
        SetTutorialComplete();
        switch (stageType)
        {
            case StagesType.tutorial:
                PlayerPrefs.SetInt("currentStageIndex", 0);
                StartGame();
                break;
            case StagesType.stageOne:
                PlayerPrefs.SetInt("currentStageIndex", 1);
                StartGame();
                break;
            case StagesType.stageTwo:
                PlayerPrefs.SetInt("currentStageIndex", 2);
                StartGame();
                break;
        }
    }
}
