using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StageOne : Stage
{
    protected override void InitializeStage(List<ClueController> clueControllers, List<ClueController> solutionControllers)
    {
        stageIdentifier = "Default";

        this.solvedClue = new List<bool> { false, true, true, false, true, false, true, false };

        this.clueNotes = new List<ClueNote> 
        { 
            new ClueNote("Talvez consiga ver alguma informação do suspeito na tabela Alunos", "Caio Bezerra (152354) está inscrito com cota de baixa renda", 
                new Clue(new List<ClueIdentifier> 
                    {
                        new ClueIdentifier("nome", "Caio"),
                        new ClueIdentifier("sobrenome", "Bezerra"),
                        new ClueIdentifier("tipo", "baixa renda"),
                    }
                )
            ),

            new ClueNote("Talvez os seguranças tenham visto algo interessante", "Houve um relato de um jovem chegando muito machucado a faculdade",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("nome", "Um jovem que tem vindo quase todos os dias estava todo ferido sentado perto das máquinas."),
                    }
                )
            ),
            // Caio e amigos logaram entraram no laboratório todos os dias que antecederam o ataque
            new ClueNote("Será que o culpado visitou a cena do crime algumas vezes antes?", "O aluno de matricula 152354 foi no laboratório todos os dias que antecederam o ataque",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("entrada", "2022-04-"),
                    new ClueIdentifier("matriculaAluno", "152354"),
                })
            ),

            //Caio, Thiago e Vitor cursam as mesmas matérias na faculdade
            new ClueNote("Será que ele estava sozinho?", "Caio cursa Cálculo I",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Caio"),
                    new ClueIdentifier("nomeMateria", "Cálculo I"),
                )
            ),

            new ClueNote("Será que ele estava sozinho?", "Thiago cursa Cálculo I",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Thiago"),
                    new ClueIdentifier("nomeMateria", "Cálculo I"),
                })
            ),

            new ClueNote("Será que ele estava sozinho?", "Vitor cursa Cálculo I",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nomeAluno", "Vitor"),
                    new ClueIdentifier("nomeMateria", "Cálculo I"),
                })
            ),

            new ClueNote("Talvez os seguranças tenham visto algo interessante", "Segundo um relato dos seguranças, houve uma briga entre dois alunos na noite do roubo",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("relatorio", "Dois meninos brigaram feio"),
                })
            ),

            new ClueNote("Alguns alunos podem chamar sua atenção", "Há um aluno chamado Vitor Milioni (155623)",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nome", "Vitor"),
                    new ClueIdentifier("sobrenome", "Milioni"),
                })
            ),

            new ClueNote("Alguns alunos podem chamar sua atenção", "Há um aluno chamado Thiago Damasceno (163224)",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nome", "Thiago"),
                    new ClueIdentifier("sobrenome", "Damasceno"),
                })
            ),

            new ClueNote("Talvez os seguranças tenham visto algo interessante", "Alguns seguranças relataram alunos com comportamento suspeito",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("relatorio", @"(andando|perambulado) pelo laboratório"),
                })
            ),

            new ClueNote("Talvez tenha algo nos registros de entrada e login nos computadores", "Caio ficou um longo período no laboratório perambulado sem de fato usar os computadores",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("matriculaAluno", "152354"),
                    new ClueIdentifier("entrada", @"(19|20|21|22)/04/2022"),
                    new ClueIdentifier("login", @"(19|20|21|22)/04/2022"),
                })
            ),

            new ClueNote("Talvez tenha algo nos registros de entrada e login nos computadores", "Thiago ficou um longo período no laboratório perambulado sem de fato usar os computadores",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("matriculaAluno", "155623"),
                    new ClueIdentifier("entrada", @"(19|20|21|22)/04/2022"),
                    new ClueIdentifier("login", @"(19|20|21|22)/04/2022"),
                })
            ),

            new ClueNote("Talvez tenha algo nos registros de entrada e login nos computadores", "Vitor ficou um longo período no laboratório perambulado sem de fato usar os computadores",
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("matriculaAluno", "163224"),
                    new ClueIdentifier("entrada", @"(19|20|21|22)/04/2022"),
                    new ClueIdentifier("login", @"(19|20|21|22)/04/2022"),
                })
            ),
        };

        int i = 0;
        foreach(ClueNote clueNote in clueNotes)
        {
            if (i >= clueControllers.Count) break;
            clueNote.SetController(clueControllers[i]);
            i++;
        }
    }
}
