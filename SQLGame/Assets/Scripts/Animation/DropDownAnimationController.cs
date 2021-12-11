using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownAnimationController : MonoBehaviour
{
    private bool open = false;
    private float hiddenDuration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        HiddenWithScale(0f);
    }

    public void Toggle()
    {
        if(open)
        {
            HiddenWithScale(hiddenDuration);
        }
        else
        {
            ShowWithScale(hiddenDuration);
        }
        open = !open;
    }

    private void HiddenWithScale(float duration)
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector3(1, 0, 1), duration);
    }

    private void ShowWithScale(float duration)
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector3(1, 1, 1), duration);
    }
}
