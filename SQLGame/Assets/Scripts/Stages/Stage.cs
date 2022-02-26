using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Stage: MonoBehaviour
{
    public List<bool> solvedClue { get; protected set; }
    protected List<ClueNote> clueNotes;
    protected List<ClueSolution> clueSolutions;

    protected string stageIdentifier = "Default";

    public void OnStart(List<ClueController> clueControllers, List<ClueController> solutionControllers)
    {
        this.clueSolutions = new List<ClueSolution>();
        InitializeStage(clueControllers, solutionControllers);
        UpdateStatuses(RetrieveSolvedClues());
    }

    public void FindClue(int index)
    {
        solvedClue[index] = true;
    }

    protected virtual void InitializeStage(List<ClueController> clueGameObjects, List<ClueController> solutionGameObjects) { /*should be override by subclasses*/ }
    protected bool UpdateStatuses(List<bool> clueStatuses) {
        if (this.clueNotes == null || this.clueNotes.Count <= 0) return false;

        for(int i = 0; i < this.clueNotes.Count; i++)
        {
            if (i >= clueStatuses.Count) break;
            this.clueNotes[i].clues.ForEach(clue => clue.found = clueStatuses[i]);
        }

        return true;
    }

    protected List<bool> RetrieveSolvedClues()
    {
        if(this.stageIdentifier == null || this.stageIdentifier == "Default" || !PlayerPrefs.HasKey(CountIdentifier())) return null;

        List<bool> clueStatuses = new List<bool>();
        int count = PlayerPrefs.GetInt(CountIdentifier());

        for (int i = 0; i < count; i++)
            clueStatuses.Add(PlayerPrefs.GetInt(ClueIdentifier(i)) == 1);

        return clueStatuses;
    }

    public bool SaveSolvedClues()
    {
        if (this.stageIdentifier == null || this.stageIdentifier == "Default") return false;

        PlayerPrefs.SetInt(CountIdentifier(), this.clueNotes.Count);

        for (int i = 0; i < this.clueNotes.Count; i++)
            PlayerPrefs.SetInt(ClueIdentifier(i), this.clueNotes[i].IsFound() ? 1 : 0);

        return true;
    }

    protected string CountIdentifier() { return this.stageIdentifier + "_count"; }
    protected string ClueIdentifier(int i) { return this.stageIdentifier + "_clue_" + i.ToString(); }
}
