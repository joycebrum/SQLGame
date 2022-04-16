using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage1 : Stage
{
    protected override void InitializeStage()
    {
        print("Initialize Stage One");
        this.stageIdentifier = "stage_one";
        this.sqlCreatePath = "Stage 1/createDB";
        this.sqlPopulatePath = "Stage 1/populateDB";
        this.dbPath = "URI=file:" + Application.dataPath + "/Stage1SQLite.db";

        this.introName.text = "Fase 1 - O desaparecimento dos computadores";
        this.introPanel.gameObject.SetActive(true);
        StartCoroutine(base.DidShowIntro());

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
            new ClueSolution("Por causa da briga, não havia seguranças no laboratório"),// 1
            new ClueSolution("Caio tinha comportamento suspeito"),// 2
            new ClueSolution("Caio parecia estar esperando algo nos dias próximos ao roubo"), // 3
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
            new ClueNote("Talvez consiga ver alguma informação do suspeito na tabela Alunos", "Caio Bezerra (152354) está inscrito com cota de baixa renda",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Caio"),
                        new ClueIdentifier("sobrenome", "Bezerra"),
                        new ClueIdentifier("tipo", "baixa renda"),
                    }
                )
            ), // 0

            new ClueNote("Talvez os seguranças tenham visto algo interessante sobre ele", "Houve um relato de jovem chegando muito machucado a faculdade, que diz ter sido agredido por agiotas",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("relatorio", "Um jovem que tem vindo quase todos os dias estava todo ferido sentado perto das máquinas."),
                    }
                )
            ),// 1

            new ClueNote("Talvez os seguranças tenham visto algo interessante", "Segundo um relato dos seguranças, houve uma briga entre alguns alunos na noite do roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("relatorio", "Dois meninos brigaram feio"),
                })
            ), // 2

            new ClueNote("Talvez os seguranças tenham visto algo suspeito", "Alguns seguranças relataram um aluno com comportamento suspeito",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("relatorio", @"(andando|perambulado) pelo laboratório"),
                })
            ), // 3

            new ClueNote("Talvez tenha algo nos registros de entrada e login nos computadores", "Caio ficou um longo período no laboratório com pouco tempo logado no dia do roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Caio"),
                    new ClueIdentifier("sobrenomeAluno", "Bezerra"),
                    new ClueIdentifier("entrada", @"23/04/2022"),
                    new ClueIdentifier("login", @"23/04/2022"),
                })
            ),// 4

            new ClueNote("Talvez tenha algo nos registros de entrada e login nos computadores", "Caio ficou um longo período no laboratório com pouco tempo logado no dia anterior ao roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Caio"),
                    new ClueIdentifier("sobrenomeAluno", "Bezerra"),
                    new ClueIdentifier("entrada", @"22/04/2022"),
                    new ClueIdentifier("login", @"22/04/2022"),
                })
            ),// 5
            new ClueNote("Talvez tenha algo nos registros de entrada e login nos computadores", "Caio ficou um longo período no laboratório com pouco tempo logado dois dias antes do roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Caio"),
                    new ClueIdentifier("sobrenomeAluno", "Bezerra"),
                    new ClueIdentifier("entrada", @"21/04/2022"),
                    new ClueIdentifier("login", @"21/04/2022"),
                })
            )// 6
        };
    }
    public override bool shouShowIAChatButton()
    {
        return true;
    }
    public override ChatEnum[] ChatToBeReleasedOnEnd()
    {
        return new ChatEnum[1] { ChatEnum.ia };
    }
}
