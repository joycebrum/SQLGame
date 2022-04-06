using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0 : Stage
{
    protected override void InitializeStage()
    {
        print("Initialize Stage Zero");
        this.stageIdentifier = "stage_zero";
        this.sqlCreatePath = "Assets/Resources/Stage 0/createDB.txt";
        this.sqlPopulatePath = "Assets/Resources/Stage 0/populateDB.txt";
        this.dbPath = "db/Stage0SQLite.db";

        this.introName.text = "Tutorial";
        this.introPanel.gameObject.SetActive(true);
        StartCoroutine(base.DidShowIntro());
   
        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Pedro usou dinheiro ilicito");
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueNotes[0], clueNotes[1] });

        return clueSolution;
    }

    protected override List<ClueNote> InitializeClueNotes()
    {
        return new List<ClueNote>
        {
            new ClueNote("Qual o salario do suspeito?", "Pedro recebia 13420",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Pedro"),
                        new ClueIdentifier("sobrenome", "Correa"),
                        new ClueIdentifier("salario", "13420"),
                    }
                )
            ), // 0

            new ClueNote("Qaunto dinheiro o suspeito gastou em Março?", "Pedro gastou 37210",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Pedro"),
                        new ClueIdentifier("sobrenome", "Correa"),
                        new ClueIdentifier("gasto", "37210"),
                    }
                )
            ),// 1
        };
    }
}
