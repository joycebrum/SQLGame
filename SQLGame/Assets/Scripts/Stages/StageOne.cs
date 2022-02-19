using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StageOne : Stage
{
    // Start is called before the first frame update
    void Start()
    {
        solvedClue = new List<bool> { true, true, true, false, true, false, true, false };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
