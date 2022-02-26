using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StageOne : Stage
{
    protected void initializeStage()
    {
        stageIdentifier = "Default";

        this.solvedClue = new List<bool> { false, true, true, false, true, false, true, false };

        this.clueNotes = new List<ClueNote> 
        { 
            new ClueNote("Talvez consiga ver alguma informa��o do suspeito na tabela Alunos", "Caio Bezerra est� inscrito com cota de baixa renda", new List<Clue> 
            { 
                new Clue(new List<ClueIdentifier> 
                {
                    new ClueIdentifier("nome", "Caio"),
                    new ClueIdentifier("sobrenome", "Bezerra"),
                    new ClueIdentifier("tipo", "baixa renda"),
                })
            }),

            new ClueNote("Talvez os seguran�as tenham visto algo interessante", "Houve um relato de um jovem chegando muito machucado a faculdade", new List<Clue>
            {
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nome", "Um jovem que tem vindo quase todos os dias estava todo ferido sentado perto das m�quinas."),
                })
            }),

            new ClueNote("Ser� que o culpado visitou a cena do crime algumas vezes antes?", "Caio e amigos logaram entraram no laborat�rio todos os dias que antecederam o ataque", new List<Clue>
            {
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("entrada", "2022-04-"),
                    new ClueIdentifier("matriculaAluno", "152354"),
                }),
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nome", "Caio"),
                    new ClueIdentifier("matricula", "152354"),
                })
            }),

            /*new ClueNote("", "", new List<Clue>
            {
                new Clue(new List<ClueIdentifier>
                {
                    new ClueIdentifier("nome", "Caio"),
                })
            })*/
        };
    }
}
