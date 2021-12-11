using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using VIDE_Data;

/*
 * This is another example script that handles the data obtained from nodeData
 * It handles localization data.
 * Refer to Example3Dialogue dialogue in the VIDE Editor.
 * It is simpler and focused on showing both NPC and Player text at the same time
 * It doesn't require any VIDE_Data or VIDE_Assign component to be in the scene
 */

public class VIDEUIManager : MonoBehaviour
{
    public string dialogueNameToLoad;
    public GameObject[] playerChoices;
    private VIDE_Assign VA;
    private ChatDialogController chatDialogController;

    private const string PLAYER_MSG = "player";
    private const string NPC_MSG = "npc";


    void Start()
    {
        chatDialogController = gameObject.GetComponent<ChatDialogController>();
    }
    public void LoadChat()
    {
        //Sets the temp VIDE_Assign’s variables for the given dialogue.
        if (VD.isActive) End(null);
        VA = GameObject.Find(dialogueNameToLoad + "Assignee").GetComponent<VIDE_Assign>();
        VA.LoadState(dialogueNameToLoad);
        VD.SetAssigned(dialogueNameToLoad, VA.alias, VA.overrideStartNode, null, null);
        LoadHistory();
        Begin();
    }

    //Called by UI button
    public void Begin()
    {
        if (!VD.isActive)
        {
            VD.OnNodeChange += NodeChangeAction; //Required events
            VD.OnEnd += End; //Required events
            VD.BeginDialogue(dialogueNameToLoad);
        }
    }

    //Called by UI buttons, every button sends a different choice index
    public void ButtonChoice(int choice)
    {
        string msg = VD.nodeData.extraVars[choice.ToString()].ToString();
        VA.messageHistory.Add(new Dictionary<string, string>() { { "type", PLAYER_MSG }, { "msg", msg } });
        CreateNewPlayerMessage(msg);
        VD.nodeData.commentIndex = choice; //Set commentIndex as it acts as the picked choice
        VD.Next();
    }

    void OnDisable()
    {
        if (VA != null && VD.nodeData != null)
        {
            VA.overrideStartNode = VD.nodeData.nodeID;
            VA.SaveState(dialogueNameToLoad);
        }
        //If the script gets destroyed, let's make sure we force-end the dialogue to prevent errors
        End(null);
    }

    void CreateNewNPCMessage(string msg)
    {
        chatDialogController.SetMessage(msg);
        chatDialogController.ShowMessage();
    }

    void CreateNewPlayerMessage(string msg)
    {
        chatDialogController.SetMessage(msg);
        chatDialogController.ShowPlayerMessage();
    }

    //Called by the OnNodeChange event
    void NodeChangeAction(VD.NodeData data)
    {
        if (data.isPlayer)
        {
            SetPlayerChoices();
        }
        else
        {
            WipePlayerChoices();
            StartCoroutine(ShowNPCText());
        }
    }

    void WipePlayerChoices()
    {
        for (int i = 0; i < playerChoices.Length; i++)
        {
            playerChoices[i].SetActive(false);
        }
    }

    void SetPlayerChoices()
    {
        for (int i = 0; i < playerChoices.Length; i++)
        {
            if (i < VD.nodeData.comments.Length)
            {
                playerChoices[i].SetActive(true);
                playerChoices[i].GetComponentInChildren<Text>().text = VD.nodeData.comments[i];
            }
            else
            {
                playerChoices[i].SetActive(false);
            }
        }
    }

    IEnumerator ShowNPCText()
    {
        yield return new WaitForSeconds(3f);
        string msg = VD.nodeData.comments[VD.nodeData.commentIndex];
        VA.messageHistory.Add(new Dictionary<string, string>() { { "type", NPC_MSG }, { "msg", msg } });
        CreateNewNPCMessage(msg);
        //Automatically call next.
        VD.Next();
    }

    private void LoadHistory()
    {
        foreach (Dictionary<string, object> regs in VA.messageHistory)
        {
            switch(regs["type"])
            {
                case PLAYER_MSG:
                    CreateNewPlayerMessage((string)regs["msg"]);
                    break;
                case NPC_MSG:
                    CreateNewNPCMessage((string)regs["msg"]);
                    break;
                default:
                    break;
            }
        }
    }

    void End(VD.NodeData data)
    {
        WipePlayerChoices();
        VD.OnNodeChange -= NodeChangeAction;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }


}
