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
        public GameObject gameObject = null;
        public string[] instructions = null;
    }
    [SerializeField] private GameObject instructionPanel = null;
    [SerializeField] private Text instructionText = null;
    [SerializeField] private TutorialStep[] tutorialSteps = null;
    [SerializeField] private GameObject[] siblings = null;

    private int tutorialStepIdx = 0;
    private int instructionIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Remover a chamada o Start e chamá-lo no momento apropriadao.
        //StartTutorial();
    }

    public void OnClick()
    {
        if(tutorialStepIdx >= 0 && instructionPanel.activeSelf) NextTutorialStep();
    }

    public void StartTutorial()
    {
        instructionPanel.SetActive(true);
        NextTutorialStep();
    }

    public void StopTutorial()
    {
        instructionText.text = "";
        instructionPanel.SetActive(false);
        if (tutorialStepIdx > 0) tutorialSteps[tutorialStepIdx - 1].gameObject.GetComponent<ButtonAnimationController>().UnfocusWithAnimation();
        tutorialStepIdx = -1;
    }

    private void NextTutorialStep()
    {
        if (tutorialStepIdx >= tutorialSteps.Length)
        {
            StopTutorial();
            return;
        }

        TutorialStep tutorialStep = tutorialSteps[tutorialStepIdx];

        NextInstruction(tutorialStep);
    }

    private void NextInstruction(TutorialStep tutorialStep)
    {
        if(instructionIdx == 0)
        {
            if (tutorialStepIdx > 0) tutorialSteps[tutorialStepIdx-1].gameObject.GetComponent<ButtonAnimationController>().UnfocusWithAnimation();
            tutorialStep.gameObject.GetComponent<ButtonAnimationController>().FocusWithAnimation();
        }

        instructionText.text = tutorialStep.instructions[instructionIdx];
        instructionIdx += 1;

        if (instructionIdx >= tutorialStep.instructions.Length)
        {
            instructionIdx = 0;
            tutorialStepIdx += 1;
        }

        changeSiblingsIndex(tutorialStep);
    }

    private void changeSiblingsIndex(TutorialStep tutorialStep)
    {
        foreach (GameObject sibling in siblings)
        {
            if (sibling.CompareTag("TutorialComplementPanel"))
            {
                if (tutorialStep.gameObject.transform.parent.gameObject.name == sibling.name)
                {
                    sibling.transform.SetSiblingIndex(3);
                }
                else
                {
                    sibling.transform.SetSiblingIndex(0);
                }
            }
            else if (sibling.name == instructionPanel.name)
            {
                sibling.transform.SetSiblingIndex(2);
            }
            else
            {
                sibling.GetComponent<ButtonAnimationController>().moveOnHierachy();
            }
        }
    }

}
