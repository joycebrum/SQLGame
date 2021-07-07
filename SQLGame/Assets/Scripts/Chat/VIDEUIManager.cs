using UnityEngine;
using System.Collections;
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

    void Start()
    {
        
    }
    public void LoadChat()
    {
        //Sets the temp VIDE_Assign’s variables for the given dialogue.
        if (VD.isActive) End(null);
        VD.SetAssigned(dialogueNameToLoad, "Chat", -1, null, null);
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
        CreateNewPlayerMessage(VD.nodeData.extraVars[choice.ToString()].ToString());
        VD.nodeData.commentIndex = choice; //Set commentIndex as it acts as the picked choice
        VD.Next();
    }

    void OnDisable()
    {
        //If the script gets destroyed, let's make sure we force-end the dialogue to prevent errors
        End(null);
    }

    void CreateNewNPCMessage(string msg)
    {
        ChatDialogController chatDialogController = gameObject.GetComponent<ChatDialogController>();
        chatDialogController.SetMessage(msg);
        chatDialogController.ShowMessage();
    }

    void CreateNewPlayerMessage(string msg)
    {
        ChatDialogController chatDialogController = gameObject.GetComponent<ChatDialogController>();
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
        CreateNewNPCMessage(VD.nodeData.comments[VD.nodeData.commentIndex]);
        //Automatically call next.
        VD.Next();
    }

    void End(VD.NodeData data)
    {
        WipePlayerChoices();
        VD.OnNodeChange -= NodeChangeAction;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }


}
