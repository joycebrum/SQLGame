using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatBoxFunctions : MonoBehaviour
{
    [SerializeField] Transform messageParentPanel;
    [SerializeField] GameObject newMessagePrefab;
    string message = "";

    public void SetMessage(string message)
    {
        this.message = message;
    }

    public void ShowMessage()
    {
        if (message != "") {
            GameObject clone = (GameObject)Instantiate(newMessagePrefab);
            clone.transform.SetParent(messageParentPanel);
            print(messageParentPanel.childCount - 2);
            clone.transform.SetSiblingIndex(messageParentPanel.childCount - 2);
            clone.GetComponent<MessageFunctions>().ShowMessage(message);
        }
    }
}
