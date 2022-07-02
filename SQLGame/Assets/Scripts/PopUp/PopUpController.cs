using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    [SerializeField] private GameObject GOtext;
    [SerializeField] private DataBaseWindowController windowController;
    public void OnCloseButton()
    {
        this.gameObject.SetActive(false);
        this.windowController.OnPopUpClose();
    }

    public void ShowPopUp(string text)
    {
        GOtext.GetComponent<Text>().text = text;
        this.gameObject.SetActive(true);
    }
}
