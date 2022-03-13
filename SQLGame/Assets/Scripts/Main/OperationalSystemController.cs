using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationalSystemController : MonoBehaviour
{

    [SerializeField] GameObject phoneObject;
    [SerializeField] GameObject tableObject;
    [SerializeField] GameObject cluesWindow;

    [SerializeField] StageController stageController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("playerName", "Cris");
        PlayerPrefs.SetString("playerFullName", "Cristiano Pereira");
    }

    public void OnMenuClick()
    {
        Debug.Log("Home");
        //stageController.NextStage();
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

    public void UpdateClues()
    {
        print("cheguei na main");
        cluesWindow.GetComponent<CluesWindowController>().SetupClues();
    }

    /* Trigger Chats */

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
}
