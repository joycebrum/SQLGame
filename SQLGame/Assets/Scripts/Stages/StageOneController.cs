using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StageOneController : MonoBehaviour
{
    private List<bool> solvedClue = new List<bool> { true, true, true, false, true, false, true, false };
    [SerializeField] private MainScreenFunctions main;
    public List<bool> SolvedClue
    { 
        get
        {
            return this.solvedClue;
        }
        set
        {
            solvedClue = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindClue(int index)
    {
        solvedClue[index] = true;
        main.UpdateClues();
    }
}
