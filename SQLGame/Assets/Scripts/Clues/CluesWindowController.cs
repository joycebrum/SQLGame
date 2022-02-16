using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesWindowController: MonoBehaviour
{
    [SerializeField] private StageOneController stageOneControlls;
    [SerializeField] private List<ClueController> clues;
    [SerializeField] private List<ClueController> clueSolutions;
    [SerializeField] private ClueController finalSolution;

    private List<bool> solvedClues;
    // Start is called before the first frame update
    void Start()
    {
        solvedClues = stageOneControlls.SolvedClue;
        print("clues.count: " + clues.Count);

        for(int i = 0; i < clues.Count; i++)
        {
            print("solvedClues.count: " + solvedClues.Count + " | i: " + (i));
            if (solvedClues.Count <= i) {
                clues[i].setAsHidden();
            } else if(solvedClues[i])
            {
                clues[i].SetAsFound("Achou");
            } else
            {
                clues[i].SetAsNotFound();
            }
        }

        bool isSolved = true;
        for (int i = 0; i < clueSolutions.Count; i++)
        {
            print("solvedClues.count: " + solvedClues.Count + " | i*2: " + (i * 2));
            if (solvedClues.Count <= i*2)
            {
                clueSolutions[i].setAsHidden();
                continue;
            } else if(solvedClues[i*2] && solvedClues[i*2+1])
            {
                clueSolutions[i].SetAsFound("Chegou a conlusão");
            } else
            {
                isSolved = false;
                clueSolutions[i].SetAsSolutionNotFound();
            }
        }
        if(isSolved)
        {
            finalSolution.SetAsFound("Parabéns voce venceu");
        } else
        {
            finalSolution.SetAsSolutionNotFound();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
