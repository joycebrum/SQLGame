using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        if (result == null || result.Count == 0 || header.Count == 0) return false;

        int column_index = header.FindIndex(column_name => column_name == identifier.column);

        if (column_index < 0 || column_index >= result.Count) return false;

        return Regex.Match(result[column_index], identifier.content).Success;
    }
}
