using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    public string type;
    public GameObject menuBackgroungVertical;
    public GameObject MenuArrow;

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
        var arrowHeight = MenuArrow.GetComponent<RectTransform>().sizeDelta[1];
        if (rectTransform.sizeDelta[1] == 0)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, MenuVerticalHeight);
            var arrowPosition = MenuArrow.transform.position;
            MenuArrow.transform.position = new Vector3(arrowPosition.x, arrowPosition.y - MenuVerticalHeight + arrowHeight/2, arrowPosition.z);
        } else
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 0);
            var arrowPosition = MenuArrow.transform.position;
            MenuArrow.transform.position = new Vector3(arrowPosition.x, arrowPosition.y + MenuVerticalHeight - arrowHeight/2, arrowPosition.z);
        }
        MenuArrow.transform.Rotate(0.0f, 0.0f, 180.0f);
    } 
}
