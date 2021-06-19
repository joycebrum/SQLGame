using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatBoxFunctions : MonoBehaviour
{
    [SerializeField] Transform messageParentPanel;
    [SerializeField] GameObject newMessagePrefab;
    string message = "";
    //TODO: salvar o histórico para exibir
    List<string> messages = null;

    public void Start()
    {
        /*messages = new List<string> { "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?", "Olá tudo bem2?" };
        foreach(string msg in messages)
        {
            this.message = msg;
            this.ShowMessage();
        }*/
    }

    public void SetMessage(string message)
    {
        this.message = message;
    }

    public void ShowMessage()
    {
        if (message != "") {
            GameObject clone = (GameObject)Instantiate(newMessagePrefab);
            clone.transform.SetParent(messageParentPanel);
            //clone.transform.SetSiblingIndex(messageParentPanel.childCount - 2);
            clone.transform.localScale = new Vector3(1f, 1f, 1f);
            clone.GetComponent<MessageFunctions>().ShowMessage(message);
        }
    }
}
