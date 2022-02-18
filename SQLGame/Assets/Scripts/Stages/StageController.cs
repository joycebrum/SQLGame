using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private MainScreenFunctions main;
    public Stage currentStage;
    int currentStageIndex;
    [SerializeReference] List<Stage> stages;
    // Start is called before the first frame update
    void Start()
    {
        currentStage = stages[0];
    }
    public void FindClue(int index)
    {
        currentStage.FindClue(index);
        main.UpdateClues();
    }

    public void NextStage()
    {
        currentStageIndex++;
        currentStage = stages[currentStageIndex];
        print(currentStage);
    }
}
