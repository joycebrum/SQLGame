using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactController : MonoBehaviour
{
    [SerializeField] private ChatEnum type;
    [SerializeField] private GameObject notification;

    // Start is called before the first frame update
    void Start()
    {
        ShowNotification();
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

    public bool HasNotification()
    {
        int dialogStatus = PlayerPrefs.GetInt(GetDialogName());
        return dialogStatus == 2 || dialogStatus == 0;
    }

    public void ShowNotification()
    {
        if(HasNotification())
        {
            this.notification.SetActive(true);
        }
        else
        {
            this.notification.SetActive(false);
        }
    }

    public void ShowContact()
    {
        PlayerPrefs.SetInt("ShouldShow" + GetDialogName(), 1);
        this.gameObject.SetActive(true);
        ShowNotification();
    }

}
