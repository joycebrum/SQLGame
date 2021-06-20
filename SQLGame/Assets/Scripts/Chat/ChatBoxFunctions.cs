using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatBoxFunctions : MonoBehaviour
{
    [SerializeField] Transform messageParentPanel = null;
    [SerializeField] GameObject newMessagePrefab = null;
    string message = "";

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
            RectTransform rectTransform = clone.GetComponent<RectTransform>();
            if (message.Length > 28) {
                rectTransform.sizeDelta = new Vector2(150, 20 + ((int)message.Length / 28) * 20);
            }
            else
            {
                rectTransform.sizeDelta = new Vector2(150, 20);
            }
            clone.GetComponent<MessageFunctions>().ShowMessage(message);
            this.message = null;
        }
    }
}
