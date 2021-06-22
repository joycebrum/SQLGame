using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    public string type;
    public GameObject menuBackgroungVertical;
    public GameObject menuArrow;
    public GameObject menuButton;

    private int MenuVerticalHeight = 125;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void onClick()
    {
        switch (type)
        {
            case "Home":
                Debug.Log("Home");
                break;
            case "Back":
                Debug.Log("Back");
                break;
            case "Message":
                Debug.Log("Message");
                break;
            case "IA":
                Debug.Log("IA");
                break;
            case "Menu":
                HideMenu();
                break;
            default:
                break;
        }
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
