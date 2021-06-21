using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    public string type;

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
            default:
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
