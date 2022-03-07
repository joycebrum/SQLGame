public class SolutionPart
{
    public string description;

    public virtual bool IsFound() 
    { 
        return false; 
    } //to be implemented in subclasses

    public virtual void UpdateController() { }

    public ClueController clueController;
}
