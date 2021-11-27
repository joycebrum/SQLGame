using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleTween : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 scaleChange = new Vector3(0.08f, 0.08f, 0.08f);
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private Vector3 focusScaleChange = new Vector3(0.2f, 0.2f, 0.2f);

    private LTDescr myTween;
    private Vector3 oldPosition;
    private bool wasMoved;

    public void OnPointerEnter(BaseEventData baseEventData)
    {
        LeanTween.scale(gameObject, transform.localScale + scaleChange, duration);
    }

    public void OnPointerExit(BaseEventData baseEventData)
    {
        LeanTween.scale(gameObject, transform.localScale - scaleChange, duration);
    }

    public void FocusWithAnimation()
    {
        myTween = LeanTween.scale(gameObject, transform.localScale + scaleChange, 0.5f).setLoopType(LeanTweenType.pingPong);
    }

    public void UnfocusWithAnimation()
    {
        LeanTween.cancel(myTween.id);
    }

    public void MoveToPosition(Vector3 newPosition)
    {
        if (!wasMoved)
        {
            wasMoved = true;
            oldPosition = transform.position;
            print(oldPosition);
            print(GetComponent<RectTransform>().position);
        }

        LeanTween.move(gameObject.GetComponent<RectTransform>(), newPosition, 1f);
    }

    public void RestorePosition()
    {
        if(wasMoved)
        {
            wasMoved = false;
            LeanTween.move(gameObject, oldPosition, 1f);
        }
    }
}
