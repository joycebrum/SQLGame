using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       /* RectTransform rect = this.gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(400, 500);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCloseButton()
    {
        this.gameObject.SetActive(false);
    }
}
