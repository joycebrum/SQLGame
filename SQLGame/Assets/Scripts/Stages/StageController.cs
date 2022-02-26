using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private OperationalSystemController main;
    [SerializeField] private GameObject clueContainer;
    public Stage currentStage;
    int currentStageIndex;
    [SerializeReference] List<Stage> stages;

    private List<ClueController> clueGameObjects;
    private List<ClueController> solutionGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        currentStageIndex = 0;
        if (PlayerPrefs.HasKey("currentStageIndex"))
        {
            currentStageIndex = PlayerPrefs.GetInt("currentStageIndex");
        }
        currentStage = stages[0];

        var allClues = this.clueContainer.GetComponents<ClueController>();
        foreach (ClueController clue in allClues)
        {
            if (clue.isSolution)
            {
                solutionGameObjects.Add(clue);
            }
            else
            {
                clueGameObjects.Add(clue);
            }
        }

        this.currentStage.OnStart(clueGameObjects, solutionGameObjects);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        
        PlayerPrefs.SetInt("currentStageIndex", this.currentStageIndex);
        this.currentStage.SaveSolvedClues();
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
