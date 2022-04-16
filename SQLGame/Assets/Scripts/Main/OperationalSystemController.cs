using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OperationalSystemController : MonoBehaviour
{

    [SerializeField] GameObject phoneObject;
    [SerializeField] GameObject tableObject;
    [SerializeField] GameObject cluesWindow;
    [SerializeField] TutorialController tutorial;

    [SerializeField] StageController stageController;

    [SerializeField] GameObject IAButton;
    [SerializeField] GameObject messageButtonNotification;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("playerName", "Cris");
        PlayerPrefs.SetString("playerFullName", "Cristiano Pereira");

        if (PlayerPrefs.GetInt("ShouldShowFriend") != 1)
        {
            ContinueFriendChat();
        }
        checkTutorial();
    }

    void Update()
    {
        phoneObject.GetComponent<ChatDialogController>().HasNewChats();
    }

    public void OnMenuClick()
    {
        Debug.Log("Home");
        SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
    }

    public void OnBackClick()
    {
        Debug.Log("Back");
    }

    public void OnMessageClick()
    {
        if(phoneObject.activeInHierarchy)
        {
            phoneObject.SetActive(false);
        }
        else
        {
            phoneObject.SetActive(true);
            phoneObject.GetComponent<ChatDialogController>().ShowContacts();
        }
    }

    public void OnIAClick()
    {
        phoneObject.SetActive(true);
        phoneObject.GetComponent<ChatDialogController>().ShowChat(0, Constants.AIName);
    }

    public void OnDBButtonClick()
    {
        tableObject.SetActive(!tableObject.activeInHierarchy);
    }

    public void ToggleCluesWindow()
    {
        cluesWindow.SetActive(!cluesWindow.activeInHierarchy);
    }

    /* Trigger Chats */

    public void ReleaseChat(ChatEnum chatToBeReleased)
    {
        switch (chatToBeReleased)
        {
            case ChatEnum.ia: ContinueAIChat(); break;
            case ChatEnum.patrocinio: ContinueBossChat(); break;
            case ChatEnum.reporter: ContinueReporterChat(); break;
            case ChatEnum.amigo: ContinueFriendChat(); break;
            default: break;
        }
    }

    public void ContinueAIChat()
    {
        phoneObject.GetComponent<ChatDialogController>().ReleaseChat(ChatEnum.ia);
    }

    public void ContinueBossChat()
    {
        phoneObject.GetComponent<ChatDialogController>().ReleaseChat(ChatEnum.patrocinio);
    }

    public void ContinueReporterChat()
    {
        phoneObject.GetComponent<ChatDialogController>().ReleaseChat(ChatEnum.reporter);
    }

    public void ContinueFriendChat()
    {
        phoneObject.GetComponent<ChatDialogController>().ReleaseChat(ChatEnum.amigo);
    }

    public void ContinueChatTutorial()
    {
        phoneObject.GetComponent<ChatDialogController>().ContinueChatTutorial();
    }

    private void checkTutorial()
    {
        if(tutorial.checkTutorial("firstStepTutorialComplete"))
        {
            changeIAChatApperance(true);
            tutorial.StartTutorial(finishTutorial);
        }
    }

    private void finishTutorial()
    {
        PlayerPrefs.SetInt("firstStepTutorialComplete", 1);
        changeIAChatApperance(false);
    }

    public void checkStageConfigs(StagesType stageType)
    {
        switch (stageType)
        {
            case StagesType.tutorial:
                changeIAChatApperance(false);
                break;
            case StagesType.stageOne:
                changeIAChatApperance(true);
                break;
            case StagesType.stageTwo:
                changeIAChatApperance(true);
                break;
        }
    }

    public void changeIAChatApperance(bool shouldAppear)
    {
        IAButton.SetActive(shouldAppear);
    }

    public void setMessageNotificationVisibility(bool isVisible)
    {
        messageButtonNotification.SetActive(isVisible);
    }

    public void cheatButton()
    {
        cluesWindow.GetComponent<CluesWindowController>().ResetClues();
        stageController.NextStage();
    }

    public void SetupStage(int currentStageIndex)
    {
        tableObject.GetComponent<DataBaseWindowController>().InitializeTableData();
        checkStageConfigs((StagesType)currentStageIndex);
    }
}
