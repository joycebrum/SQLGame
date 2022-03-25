﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [Serializable]
    public enum TutorialInstructions
    {
        none,
        initialStart,
        initialConfigButton,
        initialIAButton,
        initialBDButton,
        initialCluesButton,
        initialMessageButton,
        initialEnding,
        clueWindowStart,
        clueWindowClue,
        clueWindowFinalSolution,
        clueWindowEnding
    }

    [Serializable]
    private class TutorialStep
    {
        public GameObject gameObject = null;
        public TutorialInstructions instructionType = TutorialInstructions.none;
        public string[] instructions = null;
    }
    [SerializeField] private GameObject instructionPanel = null;
    [SerializeField] private Text instructionText = null;
    [SerializeField] private TutorialStep[] tutorialSteps = null;
    [SerializeField] private GameObject[] siblings = null;

    private int tutorialStepIdx = 0;
    private int instructionIdx = 0;

    private Action completion;

    public void OnClick()
    {
        if(tutorialStepIdx >= 0 && instructionPanel.activeSelf) NextTutorialStep();
    }

    public void setupTutorial()
    {
        for(int i = 0; i<tutorialSteps.Length; i++)
        {
            switch(tutorialSteps[i].instructionType)
            {
                case TutorialInstructions.initialStart:
                    tutorialSteps[i].instructions = Constants.initialTutorialStartInstructions;
                    break;
                case TutorialInstructions.initialConfigButton:
                    tutorialSteps[i].instructions = Constants.initialConfigButtonInstructions;
                    break;
                case TutorialInstructions.initialIAButton:
                    tutorialSteps[i].instructions = Constants.initialIAButtonInstructions;
                    break;
                case TutorialInstructions.initialBDButton:
                    tutorialSteps[i].instructions = Constants.initialBDButtonInstructions;
                    break;
                case TutorialInstructions.initialCluesButton:
                    tutorialSteps[i].instructions = Constants.initialCluesButtonInstructions;
                    break;
                case TutorialInstructions.initialMessageButton:
                    tutorialSteps[i].instructions = Constants.initialMessageButtonInstructions;
                    break;
                case TutorialInstructions.initialEnding:
                    tutorialSteps[i].instructions = Constants.initialTutorialEndingInstructions;
                    break;
                case TutorialInstructions.clueWindowStart:
                    tutorialSteps[i].instructions = Constants.clueWindowTutorialStartInstructions;
                    break;
                case TutorialInstructions.clueWindowClue:
                    tutorialSteps[i].instructions = Constants.clueWindowClueInstructions;
                    break;
                case TutorialInstructions.clueWindowFinalSolution:
                    tutorialSteps[i].instructions = Constants.clueWindowFinalSolutionInstructions;
                    break;
                case TutorialInstructions.clueWindowEnding:
                    tutorialSteps[i].instructions = Constants.clueWindowTutorialEndingInstructions;
                    break;
                default:
                    tutorialSteps[i].instructions = new string[] { };
                    break;
            }
        }
    }

    public void StartTutorial(Action completion)
    {
        print("oiee");
        print(tutorialSteps[0].instructions[0]);
        this.completion = completion;
        instructionPanel.SetActive(true);
        NextTutorialStep();
    }

    public void StopTutorial()
    {
        instructionText.text = "";
        instructionPanel.SetActive(false);
        if (tutorialStepIdx > 0 && tutorialSteps[tutorialStepIdx - 1].gameObject != null) 
            tutorialSteps[tutorialStepIdx - 1].gameObject.GetComponent<ButtonAnimationController>().UnfocusWithAnimation();
        tutorialStepIdx = -1;
        completion.Invoke();
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
        if(instructionIdx == 0 )
        {
            if (tutorialStepIdx > 0 && tutorialSteps[tutorialStepIdx - 1].gameObject != null) 
                tutorialSteps[tutorialStepIdx-1].gameObject.GetComponent<ButtonAnimationController>().UnfocusWithAnimation();
            if (tutorialStep.gameObject != null)
                tutorialStep.gameObject.GetComponent<ButtonAnimationController>().FocusWithAnimation();
        }

        instructionText.text = tutorialStep.instructions[instructionIdx];
        instructionIdx += 1;

        if (instructionIdx >= tutorialStep.instructions.Length)
        {
            instructionIdx = 0;
            tutorialStepIdx += 1;
        }
        if (tutorialStep.gameObject != null)
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
                    sibling.transform.SetSiblingIndex(siblings.Length - 1);
                }
                else
                {
                    sibling.transform.SetSiblingIndex(0);
                }
            }
            else if (sibling.name == instructionPanel.name)
            {
                sibling.transform.SetSiblingIndex(siblings.Length - 2);
            }
            else
            {
                sibling.GetComponent<ButtonAnimationController>().moveOnHierachy();
            }
        }
    }

}
