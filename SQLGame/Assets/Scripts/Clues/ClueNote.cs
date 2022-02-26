using System.Collections;
using System.Collections.Generic;
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

    public bool Check(List<List<string>> result)
    {
        return identifiers.TrueForAll(identifier => ResultHasIdentifier(result, identifier));
    }

    private bool ResultHasIdentifier(List<List<string>> result, ClueIdentifier identifier)
    {
        if(result == null || result.Count != 2) return false;
        
        int column_index = result[0].FindIndex(column_name => column_name == identifier.column);
        return result[1][column_index] == identifier.content;
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
        if (this.clue.found) this.clueController.SetAsFound(description);
        
        return this.clue.found;
    }

    public void SetController(ClueController clueController)
    {
        this.clueController = clueController;
        this.clueController.InitializeClue(hint);
    }

    public bool Check(List<List<string>> result)
    {
        return clue.Check(result);
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

    public void SetController(ClueController clueController)
    {
        this.clueController = clueController;
        this.clueController.InitializeSolution();
    }

    public void AddSolutionPart(SolutionPart solutionPart) { this.solutionParts.Add(solutionPart); }
    public void AddSolutionParts(List<SolutionPart> solutionParts) { this.solutionParts.AddRange(solutionParts); }
}
