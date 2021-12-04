using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenuController : MonoBehaviour
{
    private bool open = false;
    private float hiddenDuration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        HiddenWithScale();
    }

    public void Toggle()
    {
        if(open)
        {
            HiddenWithScale();
        }
        else
        {
            ShowWithScale();
        }
        open = !open;
    }

    private void HiddenWithScale()
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector3(1, 0, 1), hiddenDuration);
    }

    private void ShowWithScale()
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector3(1, 1, 1), hiddenDuration);
    }
}
