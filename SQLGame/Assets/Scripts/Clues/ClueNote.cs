using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ClueIdentifier
{
    string column;
    string content;

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
}

public class ClueNote : SolutionPart
{
    public string hint;
    public Clue clue;
    public ClueController clueController;

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
        this.clueController.SetAsNotFound(hint);
    }
}

public class ClueSolution : SolutionPart
{
    private List<SolutionPart> solutionParts;
    public ClueSolution(string description)
    {
        this.description = description;
    }
    public override bool IsFound()
    {
        return this.solutionParts.TrueForAll(clue => clue.IsFound());
    }

    public void Add(SolutionPart solutionPart) { this.solutionParts.Add(solutionPart); }
}
