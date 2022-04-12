using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class Stage: MonoBehaviour
{
    protected List<ClueNote> clueNotes;
    protected List<ClueSolution> clueSolutions;
    protected ClueSolution finalSolution;

    [SerializeReference] protected List<ClueController> clueControllers;
    [SerializeReference] protected List<ClueController> solutionControllers;
    [SerializeReference] protected ClueController finalSolutionController;
    [SerializeReference] protected StageDBController dbController;
    [SerializeReference] protected TextMeshProUGUI introName;
    [SerializeField] protected GameObject introPanel;

    protected string sqlCreatePath = "";
    protected string sqlPopulatePath = "";
    protected string dbPath = "";

    protected string stageIdentifier = "Default";
    private int fadeoutTime = 3;
    private int fadeoutActualTime = 0;

    public void OnStart()
    {
        UpdateStageData();
    }

    public void UpdateStageData()
    {
        InitializeStage();
        UpdateStatuses(RetrieveSolvedClues());
        this.dbController.InitDabaBase(dbPath, sqlCreatePath, sqlPopulatePath);
    }

    public bool CheckForClues(List<string> header, List<string> result)
    {
        bool anyFound = false;
        foreach(ClueNote clue in clueNotes)
        {
            if (clue.IsFound()) continue;

            if(clue.Check(header, result))
            {
                anyFound = true;
                clueSolutions.ForEach(clueSolution => clueSolution.UpdateController());
                finalSolution.UpdateController();
            }
        }
        return anyFound;
    }

    public virtual bool shouShowIAChatButton() { return true; }

    protected virtual List<ClueNote> InitializeClueNotes() { return null; }
    protected virtual List<ClueSolution> InitializeClueSolutions() { return new List<ClueSolution>(); }

    protected virtual ClueSolution InitializeFinalSolution() { return null; }

    protected virtual void InitializeStage() {
        this.clueNotes = InitializeClueNotes();

        int i = 0;
        foreach (ClueNote clueNote in clueNotes)
        {
            if (i >= clueControllers.Count) break;
            clueNote.SetController(clueControllers[i]);
            i++;
        }

        this.clueSolutions = InitializeClueSolutions();

        i = 0;
        foreach (ClueSolution clueSolution in clueSolutions)
        {
            if (i >= solutionControllers.Count) break;
            clueSolution.SetController(solutionControllers[i]);
            i++;
        }
        this.finalSolution = InitializeFinalSolution();
        this.finalSolution.SetController(finalSolutionController);
    }

    protected bool UpdateStatuses(List<bool> clueStatuses) {
        if (clueStatuses == null || this.clueNotes == null || this.clueNotes.Count <= 0) return false;
        for(int i = 0; i < this.clueNotes.Count; i++)
        {
            if (i >= clueStatuses.Count) break;
            this.clueNotes[i].clue.found = clueStatuses[i];
            this.clueNotes[i].UpdateController();
        }

        clueSolutions.ForEach(solution => solution.UpdateController());
        finalSolution.UpdateController();

        return true;
    }

    protected List<bool> RetrieveSolvedClues()
    {
        if (this.stageIdentifier == null || this.stageIdentifier == "Default" || !PlayerPrefs.HasKey(CountIdentifier())) return null;

        List<bool> clueStatuses = new List<bool>();
        int count = PlayerPrefs.GetInt(CountIdentifier());

        for (int i = 0; i < count; i++)
            clueStatuses.Add(PlayerPrefs.GetInt(ClueIdentifier(i)) == 1);
        return clueStatuses;
    }

    public bool SaveSolvedClues()
    {
        if (this.stageIdentifier == null || this.stageIdentifier == "Default" || this.clueNotes == null) return false;

        PlayerPrefs.SetInt(CountIdentifier(), this.clueNotes.Count);

        for (int i = 0; i < this.clueNotes.Count; i++)
            PlayerPrefs.SetInt(ClueIdentifier(i), this.clueNotes[i].IsFound() ? 1 : 0);

        return true;
    }

    protected string CountIdentifier() { return this.stageIdentifier + "_count"; }
    protected string ClueIdentifier(int i) { return this.stageIdentifier + "_clue_" + i.ToString(); }

    protected IEnumerator DidShowIntro()
    {
        yield return new WaitForSeconds(3);
        this.introPanel.gameObject.SetActive(false);
    }
}
