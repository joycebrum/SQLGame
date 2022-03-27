using System;
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
        messageWindowStart,
        messageWindowContact,
        messageWindowChat,
        messageWindowEnd,
        clueWindowStart,
        clueWindowClue,
        clueWindowFinalSolution,
        clueWindowEnding,
        tableWindowStart,
        tableWindowSideBar,
        tableWindowQueryBox,
        tableWindowSearchButton,
        tableWindowEnding
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

    private string[] GetInstructionByType(TutorialInstructions instructionType)
    {
        switch (instructionType)
        {
            case TutorialInstructions.initialStart:
                return Constants.initialTutorialStartInstructions;
            case TutorialInstructions.initialConfigButton:
                return Constants.initialConfigButtonInstructions;
            case TutorialInstructions.initialIAButton:
                return Constants.initialIAButtonInstructions;
            case TutorialInstructions.initialBDButton:
                return Constants.initialBDButtonInstructions;
            case TutorialInstructions.initialCluesButton:
                return Constants.initialCluesButtonInstructions;
            case TutorialInstructions.initialMessageButton:
                return Constants.initialMessageButtonInstructions;
            case TutorialInstructions.initialEnding:
                return Constants.initialTutorialEndingInstructions;
            case TutorialInstructions.messageWindowStart:
                return Constants.messageTutorialStartInstructions;
            case TutorialInstructions.messageWindowContact:
                return Constants.messageTutorialContactInstructions;
            case TutorialInstructions.messageWindowChat:
                return Constants.messageTutorialChatInstructions;
            case TutorialInstructions.messageWindowEnd:
                return Constants.messageTutorialEndInstructions;
            case TutorialInstructions.clueWindowStart:
                return Constants.clueWindowTutorialStartInstructions;
            case TutorialInstructions.clueWindowClue:
                return Constants.clueWindowClueInstructions;
            case TutorialInstructions.clueWindowFinalSolution:
                return Constants.clueWindowFinalSolutionInstructions;
            case TutorialInstructions.clueWindowEnding:
                return Constants.clueWindowTutorialEndingInstructions;
            case TutorialInstructions.tableWindowStart:
                return Constants.tableWindowTutorialStartInstructions;
            case TutorialInstructions.tableWindowSideBar:
                return Constants.tableWindowTutorialSideBarInstructions;
            case TutorialInstructions.tableWindowQueryBox:
                return Constants.tableWindowTutorialQueryBoxInstructions;
            case TutorialInstructions.tableWindowSearchButton:
                return Constants.tableWindowTutorialSearchButtonInstructions;
            case TutorialInstructions.tableWindowEnding:
                return Constants.tableWindowTutorialEndingInstructions;
            default:
                return new string[] { };
        }
    }

    public void SetupTutorial()
    {
        for(int i = 0; i<tutorialSteps.Length; i++)
        {
            tutorialSteps[i].instructions = GetInstructionByType(tutorialSteps[i].instructionType);
        }
    }

    public void StartTutorial(Action completion)
    {
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
            ChangeSiblingsIndex(tutorialStep);
    }

    private void ChangeSiblingsIndex(TutorialStep tutorialStep)
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

    public bool checkTutorial(string completionIdentifier)
    {
        if (PlayerPrefs.GetInt(completionIdentifier) == 0)
        {
            setupTutorial();
            return true;
        }
        return false;
    }

}
