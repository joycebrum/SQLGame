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

    public Sprite getNPCSprite()
    {
        VA = GameObject.Find(dialogueNameToLoad + "Assignee").GetComponent<VIDE_Assign>();
        return VA.defaultNPCSprite;
    }

    //Called by UI button
    public void Begin()
    {
        if (!VD.isActive)
        {
            VD.OnNodeChange += NodeChangeAction; //Required events
            VD.OnActionNode += ActionNodeHandler;
            VD.OnEnd += End; //Required events
            VD.BeginDialogue(dialogueNameToLoad);
        }
        if (PlayerPrefs.GetInt(dialogueNameToLoad) == 2) // 0 or null - not blocked; 1 - blocked; 2 - released
        {
            PlayerPrefs.SetInt(dialogueNameToLoad, 0);
            VD.Next();
        }
    }

    //Called by UI buttons, every button sends a different choice index
    public void ButtonChoice(int choice)
    {
        string msg = VD.nodeData.comments[choice];
        if (VD.nodeData.extraVars.Count > choice)
        {
            msg = VD.nodeData.extraVars[choice.ToString()].ToString();
        }
        VA.messageHistory.Add(new Dictionary<string, string>() { { "type", PLAYER_MSG }, { "msg", msg } });
        CreateNewPlayerMessage(msg);
        VD.nodeData.commentIndex = choice; //Set commentIndex as it acts as the picked choice
        VD.Next();
    }

    void OnDisable()
    {
        if (VA != null && VD.nodeData != null)
        {
            // Do not override if blocked because the action has already override
            if (PlayerPrefs.GetInt(dialogueNameToLoad) != 1) OverrideStartNode(VD.nodeData.nodeID);
            VA.SaveState(dialogueNameToLoad);
        }
        //If the script gets destroyed, let's make sure we force-end the dialogue to prevent errors

        End(null);
    }

    public void OverrideStartNode(int idNode)
    {
        VA.overrideStartNode = idNode;
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

    void ActionNodeHandler(int actionNodeID)
    {
        OverrideStartNode(actionNodeID);
        if(PlayerPrefs.GetInt(dialogueNameToLoad) == 0) PlayerPrefs.SetInt(dialogueNameToLoad, 1);
        WipePlayerChoices();
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
        VD.OnActionNode -= ActionNodeHandler;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }


}
