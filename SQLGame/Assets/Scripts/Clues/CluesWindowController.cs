using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesWindowController: MonoBehaviour
{
    [SerializeField] private StageController stageController;
    [SerializeField] private GameObject finalSolution;
    [SerializeField] private TutorialController tutorial;
    [SerializeField] private List<GameObject> allClues;

    private List<GameObject> clues;
    private List<GameObject> clueSolutions;
    private List<bool> solvedClues;

    private void Start()
    {
        if(tutorial.checkTutorial("CluesTutorialComplete" ))
        {
            tutorial.StartTutorial(finishTutorial);
        }
    }

    private void finishTutorial()
    {
        PlayerPrefs.SetInt("CluesTutorialComplete", 1);
    }

    public void DidTapFinalSolution()
    {
        if(finalSolution.GetComponent<ClueController>().isSolved)
        {
            ResetClues();
            this.gameObject.SetActive(false);
            stageController.NextStage();
        }
    }

    public void ResetClues()
    {
        for (int i = 0; i < allClues.Count; i++)
        {
            allClues[i].GetComponent<ClueController>().SetAsHidden();
        }
    }
}
