using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0 : Stage
{
    protected override void InitializeStage()
    {
        print("Initialize Stage Zero");
        this.stageIdentifier = "stage_zero";
        this.sqlCreatePath = "Stage 0/createDB";
        this.sqlPopulatePath = "Stage 0/populateDB";
        this.dbPath = "URI=file:" + Application.dataPath + "/Stage0SQLite.db";

        this.introName.text = "Tutorial";
   
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

            new ClueNote("Quanto dinheiro o suspeito gastou em Março?", "Pedro gastou 37210",
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

    public override bool shouldShowIAChatButton()
    {
        return false;
    }

    public override ChatEnum[] ChatToBeReleasedOnStart()
    {
        return new ChatEnum[1] { ChatEnum.amigo };
    }
}
