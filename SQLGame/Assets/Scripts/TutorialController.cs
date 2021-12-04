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
        public Vector3 position;
    }
    [SerializeField] private GameObject instructionPanel;
    [SerializeField] private Text instructionText;
    [SerializeField] private TutorialStep[] tutorialSteps;
    private int tutorialStepIdx = 0;
    private int instructionIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Remover a chamada o Start e chamá-lo no momento apropriadao.
        StartTutorial();
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
        if (tutorialStepIdx > 0) tutorialSteps[tutorialStepIdx - 1].gameObject.GetComponent<ScaleTween>().UnfocusWithAnimation();
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
            if(tutorialStepIdx > 0) tutorialSteps[tutorialStepIdx-1].gameObject.GetComponent<ScaleTween>().UnfocusWithAnimation();
            tutorialStep.gameObject.GetComponent<ScaleTween>().FocusWithAnimation();
        }

        instructionText.text = tutorialStep.instructions[instructionIdx];
        instructionIdx += 1;

        if (instructionIdx >= tutorialStep.instructions.Length)
        {
            instructionIdx = 0;
            tutorialStepIdx += 1;
        }
    }


}
