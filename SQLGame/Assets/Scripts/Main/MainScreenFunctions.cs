using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenFunctions : MonoBehaviour
{
    public GameObject menuBackgroungVertical;
    public GameObject menuButton;

    [SerializeField] GameObject phoneObject;
    [SerializeField] GameObject tableObject;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetString("playerName", "Joyce");
    }

    public void OnHomeClick()
    {
        Debug.Log("Home");
    }

    public void OnBackClick()
    {
        Debug.Log("Back");
    }

    public void OnMessageClick()
    {
        if(phoneObject.activeInHierarchy)
        {
            phoneObject.SetActive(false);
        }
        else
        {
            phoneObject.SetActive(true);
            phoneObject.GetComponent<ChatDialogController>().ShowContacts();
        }
    }

    public void OnIAClick()
    {
        phoneObject.SetActive(true);
        phoneObject.GetComponent<ChatDialogController>().ShowChat(0, Constants.AIName);
    }

    public void OnMenuClick()
    {
        tableObject.SetActive(true);
    }

    public void OnDBButtonClick()
    {
        tableObject.SetActive(!tableObject.activeInHierarchy);
    }
}
