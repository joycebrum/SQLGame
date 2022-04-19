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
        print("1");
        ChatEnum[] chatsToBeReleased = currentStage.ChatToBeReleasedOnEnd();
        print("2");
        foreach (ChatEnum chatTobeRelesead in chatsToBeReleased)
        {
            main.ReleaseChat(chatTobeRelesead);
        }
        print("3");
        currentStageIndex++;
        print("stages.Count: " + stages.Count + " | currentStageIndex: " + currentStageIndex);
        if (stages.Count == currentStageIndex)
        {
            currentStage.FinishGame();
        } else
        {
            currentStage = stages[currentStageIndex];
            print("4");
            updateStageData();
            print("5");
            main.SetupStage(currentStageIndex: currentStageIndex);
            print("6");
        }
        
    }

    public void updateStageData()
    {
        currentStage.UpdateStageData();
    }

    public bool shouldShowIAChatIcon()
    {
        return stages[currentStageIndex].shouShowIAChatButton();
    }
}
