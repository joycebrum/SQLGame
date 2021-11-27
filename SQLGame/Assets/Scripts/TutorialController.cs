using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [Serializable]
    private class TutorialStep
    {
        public GameObject gameObject;
        public string[] instructions;
    }
    [SerializeField] private TutorialStep[] tutorialSteps;
    [SerializeField] private Text instructionText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartTutorial");
    }

    public IEnumerator StartTutorial()
    {
        foreach(TutorialStep tutorialStep in tutorialSteps)
        {
            yield return StartCoroutine("ExecuteTutorialStep", tutorialStep);
        }
        gameObject.GetComponent<ScaleTween>().RestorePosition();
    }

    private IEnumerator ExecuteTutorialStep(TutorialStep tutorialStep)
    {
        tutorialStep.gameObject.GetComponent<ScaleTween>().FocusWithAnimation();
        gameObject.GetComponent<ScaleTween>().MoveToPosition(tutorialStep.gameObject.transform.position - new Vector3(290, -104, 0));

        foreach (string instruction in tutorialStep.instructions)
        {
            instructionText.text = instruction;
            yield return new WaitForSeconds(5f);
        }
    }


}
