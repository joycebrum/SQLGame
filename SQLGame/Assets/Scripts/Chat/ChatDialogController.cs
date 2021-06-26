using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatDialogController : MonoBehaviour
{
    [SerializeField] Transform messageParentPanel = null;
    [SerializeField] GameObject newMessagePrefab = null;
    string message = "";


    public void Start()
    {
    }


    public void SetMessage(string message)
    {
        this.message = message;
    }

    public void ShowMessage()
    {
        if (message != "")
        {
            GameObject clone = (GameObject)Instantiate(newMessagePrefab);
            clone.transform.SetParent(messageParentPanel);
            clone.transform.localScale = new Vector3(1f, 1f, 1f);
            RectTransform rectTransform = clone.GetComponent<RectTransform>();
            if (message.Length > 28)
            {
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
