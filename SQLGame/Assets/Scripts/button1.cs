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
        var rectTransform = menuBackgroungVertical.GetComponent<RectTransform>();
        var menuTransform = menuButton.GetComponent<RectTransform>();
        var arrowPosition = menuArrow.transform.position;
        var buttonPosition = menuButton.transform.localPosition;
        var rectPosition = menuBackgroungVertical.transform.localPosition;
        if (menuBackgroungVertical.activeSelf)
        {
            menuBackgroungVertical.SetActive(false);
            var v = menuArrow.transform.position;
            v.Set(arrowPosition.x, 0109, arrowPosition.z);
            menuArrow.transform.position = v;
        } else
        {
            menuBackgroungVertical.SetActive(true);
            var v = menuArrow.transform.position;
            v.Set(arrowPosition.x, 0, arrowPosition.z);
            menuArrow.transform.position = v;
        }
        menuArrow.transform.Rotate(0.0f, 0.0f, 180.0f);
    } 
}
