using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : Stage
{
    protected override void InitializeStage()
    {
        this.stageIdentifier = "stage_three";
        this.sqlCreatePath = "Stage 3/createDB";
        this.sqlPopulatePath = "Stage 3/populateDB";
        this.dbPath = "URI=file:" + Application.persistentDataPath + "/Stage3SQLite.db";

        this.introName.text = "Fase 3 - O Assassinato";

        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Felicia Castro assassinou Caio Porto para se vingar do ass�dio e da demiss�o");
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueSolutions[0], clueSolutions[1], clueNotes[0], clueNotes[1], clueSolutions[2] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution("Felicia Castro havia sido demitida por acusar Caio Porto de ass�dio"),// 0
            new ClueSolution("Felicia desejava que Caio estivesse morto em conversa com amiga"),// 1
            new ClueSolution("Os suspeitos s�o: Lucas Silveira, Marcos Costa e Felicia Castro"),// 2
                
            new ClueSolution("Lucas Silveira fora demitido a pedido de Caio Porto, que n�o o achava competente"), // 3
            new ClueSolution("Marcos Costa pareceu acreditar que Caio Porto estava envolvido com sua esposa"), // 4
        };

        tempList[0].AddSolutionParts(new List<SolutionPart> { this.clueNotes[7], this.clueNotes[8] });
        tempList[1].AddSolutionParts(new List<SolutionPart> { this.clueNotes[9] });
        tempList[2].AddSolutionParts(new List<SolutionPart> { this.clueNotes[2], this.clueNotes[3], this.clueNotes[4] });
        tempList[3].AddSolutionParts(new List<SolutionPart> { this.clueNotes[5] });
        tempList[4].AddSolutionParts(new List<SolutionPart> { this.clueNotes[6] });

        return tempList;
    }

    protected override List<ClueNote> InitializeClueNotes()
    {
        return new List<ClueNote>
        {
            new ClueNote("Caio tinha ido no shopping encontrar alguem?", "Felicia marcou um encontro com Caio no Shopping no dia em que ele foi assassinado",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome_origem", "Felicia Castro"),
                        new ClueIdentifier("nome_destino", "Caio Porto"),
                        new ClueIdentifier("mensagem", @"O que vc acha de sairmos"),
                    }
                )
            ), // 0

            new ClueNote("Algumas mensagens no dia da morte de Caio podem ser suspeitas", "Felicia Castro atraiu Caio at� o banheiro feminino, onde seu corpo foi encontrado",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome_origem", "Felicia Castro"),
                        new ClueIdentifier("nome_destino", "Caio Porto"),
                        new ClueIdentifier("mensagem", @"To no banheiro do bloco 13"),
                    }
                )
            ),// 1

            new ClueNote("Quem foi a segunda pessoa que mais mandou mensagem para Caio? (Suspeito A)", "Lucas Silveira foi a segunda pessoa que mais mandou mensagens para Caio Porto",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "11"),
                        new ClueIdentifier("nome_origem", "Lucas Silveira")
                    }
                )
            ),// 2

            new ClueNote("Quem foi a terceira pessoa que mais mandou mensagem para Caio? (Suspeito B)", "Marcos Costa foi a terceira pessoa que mais mandou mensagens para Caio Porto",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "9"),
                        new ClueIdentifier("nome_origem", "Marcos Costa")
                    }
                )
            ),// 3

            new ClueNote("Quem foi a pessoa que mais mandou mensagem para Caio? (suspeito C)", "Felicia Castro foi a pessoa que mais mandou mensagens para Caio Porto",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "16"),
                        new ClueIdentifier("nome_origem", "Felicia Castro")
                    }
                )
            ),// 4

            new ClueNote("Qual seria o motivo da demiss�o do suspeito A?", "O motivo da demiss�o de Lucas Silveira era dito como baixo rendimento",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Lucas"),
                        new ClueIdentifier("sobrenome", "Silveira"),
                        new ClueIdentifier("motivo_desligamento", "baixo rendimento"),
                    }
                )
            ),// 5

            new ClueNote("Qual motivo teria o suspeito B para matar Caio?", "Marcos Costa mandou a mensagem \"Eu n�o acredito que voc� fez isso... minha mulher cara...\"",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome_origem", "Marcos Costa"),
                        new ClueIdentifier("nome_destino", "Caio Porto"),
                        new ClueIdentifier("mensagem", @"A VIVAN � MINHA ESPOSA CARA|Como voc� pode|fudido"),
                    }
                )
            ),// 6

            new ClueNote("Qual seria o motivo da demiss�o do suspeito C?", "O motivo da demiss�o de Felicia era dito como n�o declarado",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Felicia"),
                        new ClueIdentifier("sobrenome", "Castro"),
                        new ClueIdentifier("motivo_desligamento", "n�o declarado"),

                    }
                )
            ),// 7

            new ClueNote("Qual seria o real motivo da demiss�o do suspeito C?", "Felicia havia feito uma reclama��o de assedio contra Caio Porto",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Felicia"),
                        new ClueIdentifier("sobrenome", "Castro"),
                        new ClueIdentifier("reclama��o", @"Caio Porto"),
                    }
                )
            ),// 8

            new ClueNote("algum suspeito acusou Caio de sua demiss�o?", "Felicia se ressentia de Caio Porto por sua demiss�o",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome_origem", "Felicia Castro"),
                        new ClueIdentifier("nome_destino", "Caio Porto"),
                        new ClueIdentifier("mensagem", @"minha demiss�o"),
                    }
                )
            ),// 9
        };
    }

    public override ChatEnum[] ChatToBeReleasedOnStart()
    {
        return new ChatEnum[1] { ChatEnum.soares };
    }
}
