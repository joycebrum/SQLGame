using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : Stage
{
    protected override void InitializeStage()
    {
        this.stageIdentifier = "stage_two";
        this.sqlCreatePath = "Stage 2/createDB";
        this.sqlPopulatePath = "Stage 2/populateDB";
        this.dbPath = "URI=file:" + Application.dataPath + "/Stage2SQLite.db";

        this.introName.text = "Fase 2 - Corrupção na Boi Livre";

        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Paulo Pinto fazia recorrentemente  transferências para contas pessoais");
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueSolutions[0], clueSolutions[1], clueSolutions[2], clueSolutions[3] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution("Paulo Pinto e Pedro Limas tinham a possibilidade para utilizar recursos restritos"),// 0
            new ClueSolution("Paulo Pinto ultrapassou o limite de transações"),// 1
            new ClueSolution("A soma das transações de Paulo, Pedro e Lucas eram de X reais"),// 2
            new ClueSolution("Valor de X reais de diferença nos gastos da empresa"), // 3
        };

        tempList[0].AddSolutionParts(new List<SolutionPart> { this.clueNotes[0], this.clueNotes[1] });
        tempList[1].AddSolutionParts(new List<SolutionPart> { this.clueNotes[2], this.clueNotes[3], this.clueNotes[4] });
        tempList[2].AddSolutionParts(new List<SolutionPart> { this.clueNotes[5], this.clueNotes[6], this.clueNotes[7] });
        tempList[3].AddSolutionParts(new List<SolutionPart> { this.clueNotes[8], this.clueNotes[9] });

        return tempList;
    }

    protected override List<ClueNote> InitializeClueNotes()
    {
        return new List<ClueNote>
        {
            new ClueNote("Verifique quantos usuários tinham permissão para utilizar recursos restritos", "Apenas 10 usuários tinham permissão de realizar transferências extraordinárias para contas de pessoas",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ), // 0

            new ClueNote("Veja quais usuários podiam utilizar recursos restritos", "Paulo Pinto e Pedro Lima já haviam utilizado recursos restritos",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 1
            
            new ClueNote("Verfique o limite de transações por mês", "O limite é de 10 transações extraordinárias por mês",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 2
            
            new ClueNote("Quantas transações no mês (maio) os usuários fizeram", "Paulo Pinto fez 12 transações no mês de Maio",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 3
            
            new ClueNote("Quantas transações no mês (maio) os usuários fizeram", "Pedro Lima fez 7 transações no mês de Maio",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 4
            
            new ClueNote("Quanto dinheiro da empresa os funcionários gastaram?", "Paulo gastou X reais da empresa no mês de Maio",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 5
            
            new ClueNote("Quanto dinheiro da empresa os funcionários gastaram?", "Pedro Lima gastou X reais da empresa no mês de Maio",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 6
            
            new ClueNote("Quanto dinheiro da empresa os funcionários gastaram?", "Lucas Souza gastou X reais da empresa no mês de Maio",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 7
            
            new ClueNote("Verifique a receita da empresa no mês de maio", "A receita da empresa no mês de Maio foi de R reais",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 8
            
            new ClueNote("Verifique os gastos da empresa no mês de maio", "O gastos da empresa no mês de Maio foram de G reais",
                new Clue(new List<ClueIdentifier>
                    {
                        //new ClueIdentifier("coluna", "valor")
                    }
                )
            ),// 9
        };
    }

    public override ChatEnum[] ChatToBeReleasedOnEnd()
    {
        return new ChatEnum[1] { ChatEnum.soares };
    }
}
