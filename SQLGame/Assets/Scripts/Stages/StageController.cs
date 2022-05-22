using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StagesType
{
    tutorial = 0,
    stageOne = 1,
    stageTwo = 2
}
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
        main.checkStageConfigs((StagesType)currentStageIndex);

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
        ChatEnum[] chatsToBeReleased = currentStage.ChatToBeReleasedOnEnd();
        foreach (ChatEnum chatTobeRelesead in chatsToBeReleased)
        {
            main.ReleaseChat(chatTobeRelesead);
        }
        currentStageIndex++;
        if (stages.Count == currentStageIndex)
        {
            currentStage.FinishGame();
        } else
        {
            currentStage = stages[currentStageIndex];
            UpdateStageData();
            main.SetupStage(currentStageIndex: currentStageIndex);
        }
        
    }

    public void UpdateStageData()
    {
        currentStage.UpdateStageData();
    }

    public bool ShouldShowIAChatIcon()
    {
        return stages[currentStageIndex].shouldShowIAChatButton();
    }
}
