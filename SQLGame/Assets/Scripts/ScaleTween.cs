using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleTween : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 scaleChange = new Vector3(0.08f, 0.08f, 0.08f);
    [SerializeField] private float duration = 0.2f;

    public void OnPointerEnter(BaseEventData baseEventData)
    {
        LeanTween.scale(gameObject, transform.localScale += scaleChange, duration);
    }

    public void OnPointerExit(BaseEventData baseEventData)
    {
        LeanTween.scale(gameObject, transform.localScale -= scaleChange, duration);
    }
}
