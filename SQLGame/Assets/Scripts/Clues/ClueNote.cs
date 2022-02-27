using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public struct ClueIdentifier
{
    public string column { get; private set; }
    public string content { get; private set; }

    public ClueIdentifier(string column, string content)
    {
        this.column = column;
        this.content = content;
    }
}

public class SolutionPart
{
    public string description;
    public virtual bool IsFound() { return false; } //to be implemented in subclasses
    public virtual void UpdateController() { }
    public ClueController clueController;
}

public class Clue
{
    public List<ClueIdentifier> identifiers;
    public bool found;

    public Clue(List<ClueIdentifier> identifiers)
    {

        this.identifiers = identifiers;
        this.found = false;
    }

    public bool Check(List<string> header, List<string> result)
    {
        if (found) return true;

        found = identifiers.TrueForAll(identifier => ResultHasIdentifier(header, result, identifier));
        return found;
    }

    private bool ResultHasIdentifier(List<string> header, List<string> result, ClueIdentifier identifier)
    {
        if(result == null || result.Count == 0 || header.Count == 0) return false;
        
        int column_index = header.FindIndex(column_name => column_name == identifier.column);

        if(column_index < 0 || column_index >= result.Count) return false;
        
        return Regex.Match(result[column_index], identifier.content).Success;
    }
}

public class ClueNote : SolutionPart
{
    public string hint;
    public Clue clue;

    public ClueNote(string hint, string description, Clue clue)
    {
        this.hint = hint;
        this.description = description;
        this.clue = clue;
    }

    public override bool IsFound()
    {        
        return this.clue.found;
    }

    public override void UpdateController()
    {
        if (IsFound()) this.clueController.SetAsFound(description);
        else this.clueController.SetAsNotFound(hint);
    }

    public void SetController(ClueController clueController)
    {
        this.clueController = clueController;
        this.clueController.InitializeClue(hint);
    }

    public bool Check(List<string> header, List<string> result)
    {
        clue.Check(header, result);
        UpdateController();

        return IsFound();
    }
}

public class ClueSolution : SolutionPart
{
    private List<SolutionPart> solutionParts;
    public ClueSolution(string description)
    {
        this.description = description;
        this.solutionParts = new List<SolutionPart>();
    }
    public override bool IsFound()
    {
        return this.solutionParts.TrueForAll(clue => clue.IsFound());
    }

    public override void UpdateController()
    {
        if (IsFound()) this.clueController.SetAsFound(description);
        else this.clueController.SetAsSolutionNotFound();
    }

    public void SetController(ClueController clueController)
    {
        this.clueController = clueController;
        this.clueController.InitializeSolution();
    }

    public void AddSolutionPart(SolutionPart solutionPart) { this.solutionParts.Add(solutionPart); }
    public void AddSolutionParts(List<SolutionPart> solutionParts) { this.solutionParts.AddRange(solutionParts); }
}
