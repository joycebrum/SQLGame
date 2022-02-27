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
    [SerializeField] private GameObject parentPanel = null;
    [SerializeField] private Text instructionText = null;
    [SerializeField] private TutorialStep[] tutorialSteps = null;
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


        List<Transform> components = new List<Transform>(parentPanel.GetComponentsInChildren<Transform>());
        int actualIndex = 0; 
        string highlightName = tutorialStep.gameObject.name;
        foreach (Transform panel in components)
        {
            if (panel.parent.name == "Tutorial" || panel.parent.name == "Tutorial panel" || panel.parent.name == "Menu Drop Down" || panel.name == "Buttons Panel")
            {
                continue;
            } else if (panel.name == "Tutorial panel") 
            {
                panel.SetSiblingIndex(3);
            } else if (panel.name == highlightName)
            {
                panel.SetSiblingIndex(4);
            } else
            {
                panel.SetSiblingIndex(actualIndex);
                actualIndex++;
            }
        }


        NextInstruction(tutorialStep);
    }

    private void NextInstruction(TutorialStep tutorialStep)
    {
        print("começei");
        if(instructionIdx == 0)
        {
            print("antes if dentro");
            if (tutorialStepIdx > 0) tutorialSteps[tutorialStepIdx-1].gameObject.GetComponent<ButtonAnimationController>().UnfocusWithAnimation();
            print("depois if dentro");
            tutorialStep.gameObject.GetComponent<ButtonAnimationController>().FocusWithAnimation();
        }
        print("pasou if 1");

        instructionText.text = tutorialStep.instructions[instructionIdx];
        instructionIdx += 1;

        print("antes if 2");
        if (instructionIdx >= tutorialStep.instructions.Length)
        {
            instructionIdx = 0;
            tutorialStepIdx += 1;
        }
        print("pasou if 2");
    }


}
