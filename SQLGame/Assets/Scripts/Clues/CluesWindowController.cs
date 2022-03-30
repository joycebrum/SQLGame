using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesWindowController: MonoBehaviour
{
    [SerializeField] private StageController stageController;
    [SerializeField] private List<GameObject> clues;
    [SerializeField] private List<GameObject> clueSolutions;
    [SerializeField] private GameObject finalSolution;
    [SerializeField] private TutorialController tutorial;

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

    public void SetupClues()
    {

        for (int i = 0; i < clues.Count; i++)
        {
            if (solvedClues.Count <= i)
            {
                clues[i].GetComponent<ClueController>().SetAsHidden();
            }
            else if (solvedClues[i])
            {
                clues[i].GetComponent<ClueController>().SetAsFound("Achou");
            }
            else
            {
                clues[i].GetComponent<ClueController>().SetAsNotFound("");
            }
        }

        bool isSolved = true;
        for (int i = 0; i < clueSolutions.Count; i++)
        {
            if (solvedClues.Count <= i * 2)
            {
                clueSolutions[i].GetComponent<ClueController>().SetAsHidden();
                continue;
            }
            else if (solvedClues[i * 2] && solvedClues[i * 2 + 1])
            {
                clueSolutions[i].GetComponent<ClueController>().SetAsFound("Chegou a conlusão");
            }
            else
            {
                isSolved = false;
                clueSolutions[i].GetComponent<ClueController>().SetAsSolutionNotFound();
            }
        }
        if (isSolved)
        {
            finalSolution.GetComponent<ClueController>().SetAsFound("Parabéns voce venceu");
        }
        else
        {
            finalSolution.GetComponent<ClueController>().SetAsSolutionNotFound();
        }
        UpdateSizes();
    }

    void UpdateSizes()
    {
        for (int i = 0; i < clues.Count; i++)
        {
            clues[i].GetComponent<LayoutElement>().preferredWidth = Screen.width / 5;
        }
        for (int i = 0; i < clueSolutions.Count; i++)
        {
            clueSolutions[i].GetComponent<LayoutElement>().preferredWidth = Screen.width / 5;
        }
        finalSolution.GetComponent<LayoutElement>().preferredWidth = Screen.width / 5;
    }
}
