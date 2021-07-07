using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageFunctions : MonoBehaviour
{
    [SerializeField] Text text = null;
    public void ShowMessage(string message)
    {
        text.text = message;
    }

    public void HideMessage()
    {
        Destroy(gameObject);
    }
}
