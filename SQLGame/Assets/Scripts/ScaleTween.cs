using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScaleTween : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 scaleChange = new Vector3(0.08f, 0.08f, 0.08f);
    [SerializeField] private float duration = 0.2f;
    private Vector3 focusScaleChange = new Vector3(0.2f, 0.2f, 0.2f);

    private List<LTDescr> myTweens = new List<LTDescr>();
    private Vector3 oldPosition;
    private bool wasMoved;
    private Color originalColor = Color.white;
    private Vector3 originalScale;
    private bool onFocus = false;

    public void Start()
    {
        originalColor = gameObject.GetComponent<Image>().color;
        originalScale = transform.localScale;

    }
    public void OnPointerEnter(BaseEventData baseEventData)
    {
        if (!onFocus) LeanTween.scale(gameObject, transform.localScale + scaleChange, duration);
    }

    public void OnPointerExit(BaseEventData baseEventData)
    {
        if(!onFocus) LeanTween.scale(gameObject, transform.localScale - scaleChange, duration);
    }

    public void FocusWithAnimation()
    {
        onFocus = true;
        myTweens.Add(LeanTween.scale(gameObject, transform.localScale + focusScaleChange, 0.5f).setLoopType(LeanTweenType.pingPong));
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
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), originalScale, 0.1f);
    }

}
