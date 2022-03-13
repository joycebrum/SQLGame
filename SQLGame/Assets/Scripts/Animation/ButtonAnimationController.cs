using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 scaleChange = new Vector3(0.08f, 0.08f, 0.08f);
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private bool shouldScaleOnPointEnter = true;
    private Vector3 focusScaleChange = new Vector3(0.2f, 0.2f, 0.2f);

    private List<LTDescr> myTweens = new List<LTDescr>();
    private Color originalColor = Color.white;
    private Vector3 originalScale = new Vector3(1f, 1f, 1f);
    private bool onFocus = false;

    private int sibllingIndex = 0;

    public void Start()
    {
        originalColor = gameObject.GetComponent<Image>().color;

    }
    public void OnPointerEnter(BaseEventData baseEventData)
    {
        if (shouldScaleOnPointEnter && !onFocus) LeanTween.scale(gameObject, originalScale + scaleChange, duration);
    }

    public void OnPointerExit(BaseEventData baseEventData)
    {
        if(shouldScaleOnPointEnter && !onFocus) RestoreScale(this.duration);
    }

    public void FocusWithAnimation()
    {
        onFocus = true;
        myTweens.Add(LeanTween.scale(gameObject, originalScale + focusScaleChange, 0.5f).setLoopType(LeanTweenType.pingPong));
        myTweens.Add(LeanTween.color(gameObject.GetComponent<RectTransform>(), Color.green, 0.5f).setLoopPingPong());
    }

    public void UnfocusWithAnimation()
    {
        onFocus = false;
        foreach(LTDescr myTween in myTweens)
        {
            LeanTween.cancel(myTween.id);
        }
        LeanTween.color(gameObject.GetComponent<RectTransform>(), originalColor, 0.1f);
        RestoreScale(0.1f);
    }

    public void RestoreScale(float duration)
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), originalScale, duration);
    }

    public void moveOnHierachy()
    {
        if(onFocus)
        {
            this.transform.SetSiblingIndex(3);
        } else {
            this.transform.SetSiblingIndex(0);
        }
    }
}
