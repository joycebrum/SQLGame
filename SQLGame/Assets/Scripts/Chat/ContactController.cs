using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactController : MonoBehaviour
{
    [SerializeField] private ChatEnum type;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("ShouldShow" + GetDialogName()) == 1) {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public string GetDialogName()
    {
        return ChatDialogController.GetDialogueName(type);
    }
    public void ShowContact()
    {
        PlayerPrefs.SetInt("ShouldShow" + GetDialogName(), 1);
        this.gameObject.SetActive(true);
    }

}
