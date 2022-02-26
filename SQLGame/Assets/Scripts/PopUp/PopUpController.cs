using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    [SerializeField] private GameObject GOtext;
    public void onCloseButton()
    {
        this.gameObject.SetActive(false);
    }

    public void showPopUp(string text)
    {
        GOtext.GetComponent<Text>().text = text;
        this.gameObject.SetActive(true);
    }
}
