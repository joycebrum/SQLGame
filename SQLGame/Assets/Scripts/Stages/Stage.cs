using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage: MonoBehaviour
{
    public List<bool> solvedClue { get; protected set; }
    public void FindClue(int index)
    {
        solvedClue[index] = true;
    }


}
