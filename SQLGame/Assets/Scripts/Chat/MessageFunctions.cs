using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageFunctions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text = null;
    public void ShowMessage(string message)
    {
        text.text = message;
    }

    public void HideMessage()
    {
        Destroy(gameObject);
    }
}
