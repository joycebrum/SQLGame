using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private OperationalSystemController main;
    [SerializeField] private GameObject clueContainer;
    private Stage currentStage;
    int currentStageIndex;
    [SerializeReference] List<Stage> stages;

    // Start is called before the first frame update
    void Start()
    {
        currentStageIndex = 0;
        if (PlayerPrefs.HasKey("currentStageIndex"))
        {
            currentStageIndex = PlayerPrefs.GetInt("currentStageIndex");
        }
        currentStage = stages[currentStageIndex];

        this.currentStage.OnStart();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        
        PlayerPrefs.SetInt("currentStageIndex", this.currentStageIndex);
        this.currentStage.SaveSolvedClues();
    }

    public bool CheckForClues(List<string> header, List< string > result)
    {
        return currentStage.CheckForClues(header, result);
    }

    public void NextStage()
    {
        currentStageIndex++;
        currentStage = stages[currentStageIndex];
        print(currentStage);
    }
}
