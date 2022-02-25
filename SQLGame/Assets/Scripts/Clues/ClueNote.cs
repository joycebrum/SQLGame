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

public class ClueNote
{
    public string hint;
    public string description;
    public List<Clue> clues;

    public ClueNote(string hint, string description, List<Clue> clues)
    {
        this.hint = hint;
        this.description = description;
        this.clues = clues;
    }

    public bool IsFound()
    {
        return this.clues.TrueForAll(clue => clue.found);
    }
}
