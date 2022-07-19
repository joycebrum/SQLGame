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
        this.dbPath = "URI=file:" + (Application.platform == RuntimePlatform.OSXPlayer ? Application.persistentDataPath : Application.dataPath) + "/Stage4SQLite.db";

        this.introName.text = "Fase 4 - Desaparecida";

        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Helena Peres est� em um balc�o abandonado na Travessa Juliana Andrade, em Lins de Vasconcelos, Rio de Janeiro, por a��o da mil�cia, que tem mais poder e influ�ncia do que se acredita...");
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueSolutions[0], clueSolutions[1], clueSolutions[2] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution("Al�m de ter um aumento de den�ncias de a��o de milicianos, 50% dessas den�ncias est�o censuradas fazendo ser imposs�vel chegar no culpado"),// 0
            new ClueSolution("Helena Peres tinha problemas com milicianos que tinham certo poder dentro da pol�cia"),// 1
            new ClueSolution("O telefone de Helena est� na Travessa Juliana Andrade, em Lins de Vasconcelos, Rio de Janeiro."),// 2
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
            new ClueNote("Qual o m�s com o maior numero de den�ncias semelhantes a de Helena?", "O n�mero de den�ncias sobre milicianos em abril foi a maior de todos os tempos",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "18"),
                        new ClueIdentifier(null, @"04|Abril|abril")
                    }
                )
            ), // 0
            new ClueNote("Qual porcentagem de den�ncias semelhantes a de Helena est� censurada?", "50% das den�ncias dos milicianos est�o censuradas",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "50"),
                    }
                )
            ), // 1
            new ClueNote("Helena relatou alguma situa��o suspeita para a pol�cia", "Helena Peres fez uma den�ncia de abuso policial do que parecia ser um membro da mil�cia",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Helena"),
                        new ClueIdentifier("sobrenome", "Peres"),
                        new ClueIdentifier("relato", @"perseguida por um policial")
                    }
                )
            ), // 2
            new ClueNote("Houve alguma rea��o suspeita por parte da atendente no relat de Helena?", "A atendente pareceu nervosa ao ouvir o nome censurado e aconselhou Helena a n�o se envolver",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Helena"),
                        new ClueIdentifier("sobrenome", "Peres"),
                        new ClueIdentifier("relato", @"XXX\?! Voc� n�o deveria se meter com ele")
                    }
                )
            ), // 3
            new ClueNote("Consegue descobrir o n�mero de telefone pessoal da Helena Peres?", "Helena acaba informando seu n�mero de telefone (21) 96666-9112 em uma den�ncia",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Helena"),
                        new ClueIdentifier("sobrenome", "Peres"),
                        new ClueIdentifier("relato", @"96666-9112")
                    }
                )
            ), // 4
            new ClueNote("Tendo o n�mero, encontre sua localiza��o", "O telefone (21) 96666-9112 est� na Travessa Juliana Andrade, em Lins de Vasconcelos, Rio de Janeiro",
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
