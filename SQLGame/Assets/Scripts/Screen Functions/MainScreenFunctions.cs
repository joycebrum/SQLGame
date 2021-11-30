using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenFunctions : MonoBehaviour
{
    public GameObject menuBackgroungVertical;
    public GameObject menuButton;

    [SerializeField] GameObject phoneObject;
    [SerializeField] GameObject tableObject;

    private int MenuVerticalHeight = 125;

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
        phoneObject.SetActive(true);
        phoneObject.GetComponent<ChatDialogController>().ShowContacts();
    }

    public void OnIAClick()
    {
        phoneObject.SetActive(true);
        phoneObject.GetComponent<ChatDialogController>().ShowChat(0, Configuration.AIName);
    }

    public void OnMenuClick()
    {
        tableObject.SetActive(true);
        HideMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void HideMenu()
    {
        Debug.Log("Menu");
        if (menuBackgroungVertical.activeSelf)
        {
            menuBackgroungVertical.SetActive(false);
        } else
        {
            menuBackgroungVertical.SetActive(true);
        }
    } 
}
