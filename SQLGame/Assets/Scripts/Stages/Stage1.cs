using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage1 : Stage
{
    protected override void InitializeStage()
    {
        this.stageIdentifier = "stage_one";
        this.sqlCreatePath = "Stage 1/createDB";
        this.sqlPopulatePath = "Stage 1/populateDB";
        this.dbPath = "URI=file:" + Application.dataPath + "/Stage1SQLite.db";

        this.introName.text = "Fase 1 - O desaparecimento dos computadores";

        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Caio tinha problemas financeiros e, com medo dos agiotas, esperou por uma oportunidade e roubou os computadores");
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueSolutions[0], clueSolutions[1], clueSolutions[2], clueSolutions[3] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution("Caio tinha problemas financeiros"),// 0
            new ClueSolution("Por causa da briga, n�o havia seguran�as no laborat�rio"),// 1
            new ClueSolution("Caio tinha comportamento suspeito"),// 2
            new ClueSolution("Caio parecia estar esperando algo nos dias pr�ximos ao roubo"), // 3
        };

        tempList[0].AddSolutionParts(new List<SolutionPart> {this.clueNotes[0], this.clueNotes[1]});
        tempList[1].AddSolutionPart(this.clueNotes[2]);
        tempList[2].AddSolutionParts(new List<SolutionPart> { this.clueNotes[3], tempList[3] });
        tempList[3].AddSolutionParts(new List<SolutionPart> { this.clueNotes[4], this.clueNotes[5], this.clueNotes[6] });

        return tempList;
    }

    protected override List<ClueNote> InitializeClueNotes()
    {
        return new List<ClueNote>
        {
            new ClueNote("Procure alguma informa��o do suspeito na tabela Alunos", "Caio Bezerra (152354) est� inscrito com cota de baixa renda",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Caio"),
                        new ClueIdentifier("sobrenome", "Bezerra"),
                        new ClueIdentifier("tipo", "baixa renda"),
                    }
                )
            ), // 0

            new ClueNote("Os seguran�as relataram algo que ajuda a entender o motivo do suspeito", "Houve um relato de jovem chegando muito machucado a faculdade, que diz ter sido agredido por agiotas",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("relatorio", "Um jovem estava todo ferido sentado perto das m�quinas."),
                    }
                )
            ),// 1

            new ClueNote("Alguma coisa aconteceu na noite do roubo (23 de Abril)", "Segundo um relato dos seguran�as, houve uma briga entre alguns alunos na noite do roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("relatorio", "Dois meninos brigaram feio"),
                })
            ), // 2

            new ClueNote("Os seguran�as podem saber de alguem com comportamento suspeito no laborat�rio.", "Alguns seguran�as relataram um aluno com comportamento suspeito",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("relatorio", @"(andando|perambulado) pelo laborat�rio"),
                })
            ), // 3

            new ClueNote("Alguem fez algo suspeito no dia do roubo (23 de Abril)", "Caio Bezerra ficou um longo per�odo no laborat�rio com pouco tempo logado no dia do roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Caio"),
                    new ClueIdentifier("sobrenomeAluno", "Bezerra"),
                    new ClueIdentifier("entrada", @"2022-04-23"),
                    new ClueIdentifier("login", @"2022-04-23"),
                })
            ),// 4

            new ClueNote("Alguem fez algo suspeito no dia anterior ao roubo (22 de Abril)", "Caio Bezerra ficou um longo per�odo no laborat�rio com pouco tempo logado no dia anterior ao roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Caio"),
                    new ClueIdentifier("sobrenomeAluno", "Bezerra"),
                    new ClueIdentifier("entrada", @"2022-04-22"),
                    new ClueIdentifier("login", @"2022-04-22"),
                })
            ),// 5
            new ClueNote("Alguem fez algo suspeito dois dias antes do roubo (21 de Abril)", "Caio Bezerra ficou um longo per�odo no laborat�rio com pouco tempo logado dois dias antes do roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Caio"),
                    new ClueIdentifier("sobrenomeAluno", "Bezerra"),
                    new ClueIdentifier("entrada", @"2022-04-21"),
                    new ClueIdentifier("login", @"2022-04-21"),
                })
            )// 6
        };
    }

    public override ChatEnum[] ChatToBeReleasedOnStart()
    {
        return new ChatEnum[1] { ChatEnum.ia };
    }
}
