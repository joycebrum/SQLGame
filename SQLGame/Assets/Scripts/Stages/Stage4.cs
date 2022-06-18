using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4 : Stage
{
    protected override void InitializeStage()
    {
        this.stageIdentifier = "stage_four";
        this.sqlCreatePath = "Stage 4/createDB";
        this.sqlPopulatePath = "Stage 4/populateDB";
        this.dbPath = "URI=file:" + Application.dataPath + "/Stage4SQLite.db";

        this.introName.text = "Fase 4 - Desaparecida";

        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Helena Peres está em um balcão abandonado na Travessa Juliana Andrade, em Lins de Vasconcelos, Rio de Janeiro, por ação da milícia, que tem mais poder e influência do que se acredita...");
        //clueSolution.AddSolutionParts(new List<SolutionPart> { clueSolutions[0], clueSolutions[1], clueSolutions[2], clueSolutions[3] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution(""),// 0
        };

        //tempList[0].AddSolutionParts(new List<SolutionPart> { this.clueNotes[0], this.clueNotes[1], this.clueNotes[2] });

        return tempList;
    }

    protected override List<ClueNote> InitializeClueNotes()
    {
        return new List<ClueNote>
        {
            new ClueNote("", "",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "11")
                    }
                )
            ), // 0
        };
    }

    public override ChatEnum[] ChatToBeReleasedOnStart()
    {
        return new ChatEnum[1] { ChatEnum.ia };
    }
}
