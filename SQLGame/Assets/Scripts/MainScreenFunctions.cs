using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenFunctions : MonoBehaviour
{
    public GameObject menuBackgroungVertical;
    public GameObject menuButton;

    private int MenuVerticalHeight = 125;

    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log("Message");
    }

    public void OnIAClick()
    {
        Debug.Log("IA");
    }

    public void OnMenuClick()
    {
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
