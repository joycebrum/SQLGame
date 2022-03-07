using System.Collections.Generic;

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