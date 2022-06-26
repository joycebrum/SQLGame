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
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueSolutions[0], clueSolutions[1], clueSolutions[2] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution("Além de ter um aumento de denúncias de ação de milicianos, X% dessas denúncias estão censuradas fazendo ser impossível chegar no culpado"),// 0
            new ClueSolution("Helena Peres tinha problemas com milicianos que tinham certo poder dentro da polícia"),// 1
            new ClueSolution("O telefone de Helena está na Travessa Juliana Andrade, em Lins de Vasconcelos, Rio de Janeiro."),// 2
        };

        tempList[0].AddSolutionParts(new List<SolutionPart> { this.clueNotes[0], this.clueNotes[1] });
        tempList[1].AddSolutionParts(new List<SolutionPart> { this.clueNotes[2], this.clueNotes[3] });
        tempList[2].AddSolutionParts(new List<SolutionPart> { this.clueNotes[4], this.clueNotes[5] });

        return tempList;
    }

    protected override List<ClueNote> InitializeClueNotes()
    {
        return new List<ClueNote>
        {
            new ClueNote("Qual o mês com o maior numero de denúncias semelhantes a de Helena?", "O número de denúncias sobre milicianos em abril foi a maior de todos os tempos",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "18"),
                        new ClueIdentifier(null, @"04|Abril|abril")
                    }
                )
            ), // 0
            new ClueNote("Qual porcentagem de denúncias semelhantes a de Helena está censurada?", "44% das denúncias dos milicianos estão censuradas",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "44,82"),
                    }
                )
            ), // 1
            new ClueNote("Helena relatou alguma situação suspeita para a polícia", "Helena Peres fez uma denúncia de abuso policial do que parecia ser um membro da milícia",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Helena"),
                        new ClueIdentifier("sobrenome", "Peres"),
                        new ClueIdentifier("relato", @"perseguida por um policial")
                    }
                )
            ), // 2
            new ClueNote("Helena relatou alguma situação suspeita para a polícia", "A atendente pareceu nervosa ao ouvir o nome censurado e aconselhou Helena a não se envolver",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Helena"),
                        new ClueIdentifier("sobrenome", "Peres"),
                        new ClueIdentifier("relato", @"XXX?! Você não deveria se meter com ele")
                    }
                )
            ), // 3
            new ClueNote("Consegue descobrir o número de telefone pessoal da Helena Peres?", "Helena acaba informando seu número de telefone (21) 96666-9112 em uma denúncia",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Helena"),
                        new ClueIdentifier("sobrenome", "Peres"),
                        new ClueIdentifier("relato", @"96666-9112")
                    }
                )
            ), // 4
            new ClueNote("Tendo o número, encontre sua localização", "O telefone (21) 96666-9112 está na Travessa Juliana Andrade, em Lins de Vasconcelos, Rio de Janeiro",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("telefone", @"\(21\) 96666-9112"),
                        new ClueIdentifier("endereco", "Travessa Juliana Andrade"),
                        new ClueIdentifier("bairro", "Lins de Vasconcelos"),
                        new ClueIdentifier("cidade", "Rio de Janeiro"),
                        new ClueIdentifier("estado", "RJ")
                    }
                )
            ), // 5
        };
    }

    public override ChatEnum[] ChatToBeReleasedOnStart()
    {
        return new ChatEnum[1] { ChatEnum.patrocinio };
    }
}
