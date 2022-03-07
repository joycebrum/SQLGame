using System.Collections.Generic;

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

