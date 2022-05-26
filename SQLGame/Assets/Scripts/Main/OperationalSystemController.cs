using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OperationalSystemController : MonoBehaviour
{

    [SerializeField] GameObject phoneObject;
    [SerializeField] GameObject tableObject;
    [SerializeField] GameObject cluesWindow;
    [SerializeField] TutorialController tutorial;

    [SerializeField] StageController stageController;

    [SerializeField] Button IAButton;
    [SerializeField] Button menuButton;
    [SerializeField] Button chatButton;
    [SerializeField] Button bdButton;
    [SerializeField] Button cluesButton;
    [SerializeField] GameObject messageButtonNotification;

    private bool isInTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("playerName", "Cris");
        PlayerPrefs.SetString("playerFullName", "Cristiano Pereira");

        CheckTutorial();
    }

    void Update()
    {
        phoneObject.GetComponent<ChatDialogController>().HasNewChats();
    }

    // Initial config
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

    public void setMessageNotificationVisibility(bool isVisible)
    {
        messageButtonNotification.SetActive(isVisible);
    }

    public void SetupStage(int currentStageIndex)
    {
        tableObject.GetComponent<DataBaseWindowController>().InitializeTableData();
        checkStageConfigs((StagesType)currentStageIndex);
    }

    // Buttons
    public void OnMenuClick()
    {
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

    public void cheatButton()
    {
        cluesWindow.GetComponent<CluesWindowController>().ResetClues();
        stageController.NextStage();
    }

    public void changeIAChatApperance(bool shouldAppear)
    {
        IAButton.gameObject.SetActive(shouldAppear);
    }

    public void StageDisableButtons()
    {
        bdButton.interactable = false;
        cluesButton.interactable = false;
    }
    public void StageEnableButtons()
    {
        bdButton.interactable = true;
        cluesButton.interactable = true;
    }

    public void TutorialCompleted()
    {
        this.isInTutorial = false;
        ReleaseButton();
    }

    private void DisableButtons()
    {
        menuButton.enabled = false;
        IAButton.enabled = false;
        chatButton.enabled = false;
        bdButton.enabled = false;
        cluesButton.enabled = false;
    }

    private void EnableAndBlockButtons()
    {
        menuButton.enabled = true;
        chatButton.enabled = true;
        bdButton.enabled = true;
        cluesButton.enabled = true;
        menuButton.interactable = false;
        chatButton.interactable = false;
        bdButton.interactable = false;
        cluesButton.interactable = false;
    }

    public void ReleaseButton()
    {
        if (!tutorial.checkTutorial("firstStepTutorialComplete"))
        {
            menuButton.interactable = true;
            chatButton.interactable = true;
        }
        if (!tutorial.checkTutorial("MessageTutorialComplete2"))
        {
            cluesButton.interactable = true;
        }
        if (!tutorial.checkTutorial("CluesTutorialComplete"))
        {
            bdButton.interactable = true;
            isInTutorial = true;
        }
    }

    //Tutorial

    private void CheckTutorial()
    {
        if(tutorial.checkTutorial("firstStepTutorialComplete"))
        {
            isInTutorial = true;
            DisableButtons();
            changeIAChatApperance(true);
            tutorial.StartTutorial(FinishTutorial);
        }
    }

    private void FinishTutorial()
    {
        PlayerPrefs.SetInt("firstStepTutorialComplete", 1);
        changeIAChatApperance(false);
        EnableAndBlockButtons();
        ReleaseButton();
    }

    // Chat Methods
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


    public void ContinueSoaresChat()
    {
        phoneObject.GetComponent<ChatDialogController>().ReleaseChat(ChatEnum.soares);
    }

    public void ContinueChatTutorial()
    {
        phoneObject.GetComponent<ChatDialogController>().ContinueChatTutorial();
    }
}
