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
        this.dbPath = "URI=file:" + (Application.platform == RuntimePlatform.OSXPlayer ? Application.persistentDataPath : Application.dataPath) + "/Stage3SQLite.db";

        this.introName.text = "Fase 3 - O Assassinato";

        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Felicia Castro assassinou Caio Porto para se vingar do assédio e da demissão");
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueSolutions[0], clueSolutions[1], clueNotes[0], clueNotes[1], clueSolutions[2] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution("Felicia Castro havia sido demitida por acusar Caio Porto de assédio"),// 0
            new ClueSolution("Felicia desejava que Caio estivesse morto em conversa com amiga"),// 1
            new ClueSolution("Os suspeitos são: Lucas Silveira, Marcos Costa e Felicia Castro"),// 2
                
            new ClueSolution("Lucas Silveira fora demitido a pedido de Caio Porto, que não o achava competente"), // 3
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

            new ClueNote("Algumas mensagens no dia da morte de Caio podem ser suspeitas", "Felicia Castro atraiu Caio até o banheiro feminino, onde seu corpo foi encontrado",
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

            new ClueNote("Qual seria o motivo da demissão do suspeito A?", "O motivo da demissão de Lucas Silveira era dito como baixo rendimento",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Lucas"),
                        new ClueIdentifier("sobrenome", "Silveira"),
                        new ClueIdentifier("motivo_desligamento", "baixo rendimento"),
                    }
                )
            ),// 5

            new ClueNote("Qual motivo teria o suspeito B para matar Caio?", "Marcos Costa mandou a mensagem \"Eu não acredito que você fez isso... minha mulher cara...\"",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome_origem", "Marcos Costa"),
                        new ClueIdentifier("nome_destino", "Caio Porto"),
                        new ClueIdentifier("mensagem", @"A VIVAN é MINHA ESPOSA CARA|Como você pode|fudido"),
                    }
                )
            ),// 6

            new ClueNote("Qual seria o motivo da demissão do suspeito C?", "O motivo da demissão de Felicia era dito como não declarado",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Felicia"),
                        new ClueIdentifier("sobrenome", "Castro"),
                        new ClueIdentifier("motivo_desligamento", "não declarado"),

                    }
                )
            ),// 7

            new ClueNote("Qual seria o real motivo da demissão do suspeito C?", "Felicia havia feito uma reclamação de assedio contra Caio Porto",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Felicia"),
                        new ClueIdentifier("sobrenome", "Castro"),
                        new ClueIdentifier("reclamação", @"Caio Porto"),
                    }
                )
            ),// 8

            new ClueNote("algum suspeito acusou Caio de sua demissão?", "Felicia se ressentia de Caio Porto por sua demissão",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome_origem", "Felicia Castro"),
                        new ClueIdentifier("nome_destino", "Caio Porto"),
                        new ClueIdentifier("mensagem", @"minha demissão"),
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
