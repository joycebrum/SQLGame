using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : Stage
{
    public bool released = false;
    protected override void InitializeStage()
    {
        this.stageIdentifier = "stage_five";
        this.sqlCreatePath = "Stage 5/createDB";
        this.sqlPopulatePath = "Stage 5/populateDB";
        this.dbPath = "URI=file:" + (Application.platform == RuntimePlatform.OSXPlayer ? Application.persistentDataPath : Application.dataPath) + "/Stage5SQLite.db";

        this.introName.text = "Fase 5 - Justi�a";
        this.released = PlayerPrefs.GetInt(stageIdentifier + "_released") == 1 || false;

        base.InitializeStage();
    }

    protected override ClueSolution InitializeFinalSolution()
    {
        ClueSolution clueSolution = new ClueSolution("Helena Peres foi assassinada por Carlos Patroc�nio, Miliciano e Coronel da Pol�cia. Soares estava apenas tentando ajudar");
        clueSolution.AddSolutionParts(new List<SolutionPart> { clueNotes[9], clueSolutions[0], clueSolutions[1], clueSolutions[2], clueSolutions[3], clueSolutions[4] });

        return clueSolution;
    }

    protected override List<ClueSolution> InitializeClueSolutions()
    {
        List<ClueSolution> tempList = new List<ClueSolution>
        {
            new ClueSolution("Soares estava tentando ajudar Helena Peres"),// 0
            new ClueSolution("Soares consegue encontrar Helena antes por informa��es que ela lhe passara pelo celular"),// 1
            new ClueSolution("O relato de Helena Peres � sobre Carlos Patroc�nio"),// 2
            new ClueSolution("Os nomes citados de Milicianos s�o Carlos Patroc�nio, Joaquim Barbosa e Paulo Moreira"),// 3
            new ClueSolution("Carlos Patroc�nio tem a maior patente dentre os tr�s")// 4
        };

        tempList[0].AddSolutionParts(new List<SolutionPart> { this.clueNotes[0], this.clueNotes[1]});
        tempList[1].AddSolutionParts(new List<SolutionPart> { this.clueNotes[2] });
        tempList[2].AddSolutionParts(new List<SolutionPart> { tempList[3], tempList[4] });
        tempList[3].AddSolutionParts(new List<SolutionPart> { this.clueNotes[3], this.clueNotes[4], this.clueNotes[5] });
        tempList[4].AddSolutionParts(new List<SolutionPart> { this.clueNotes[6], this.clueNotes[7], this.clueNotes[8] });

        return tempList;
    }

    protected override List<ClueNote> InitializeClueNotes()
    {
        return new List<ClueNote>
        {
            new ClueNote("Qual a conex�o de Helena com a pesssoa a quem ela pediu ajuda?", "Soares era marido de uma amiga �ntima de Helena",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "Soares"),
                        new ClueIdentifier(null, "marido da Vivi")
                    }
                )
            ), // 0
            new ClueNote("Helena pediu ajuda a algu�m", "Soares disse que faria o poss�vel para ajudar Helena e pediu para que ela tomasse cuidado",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "Soares"),
                        new ClueIdentifier(null,  "vou te ajudar")
                    }
                )
            ), // 1
            new ClueNote("Helena havia compartilhado alguma informa��o importante com algu�m no dia de sua morte?", "No dia do sequestro Helena pediu ajuda para Soares e conseguiu passar sua localiza��o",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "Soares"),
                        new ClueIdentifier(null,  "llocaliza��o")
                    }
                )
            ), // 2
            new ClueNote("Quem s�o os Milicianos(Miliciano 1)", "Joaquim Barbosa � um miliciano",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("relato", "Joaquim Barbosa")
                    }
                )
            ), // 3
            new ClueNote("Quem s�o os Milicianos(Miliciano 2)", "Paulo Moreira � um miliciano",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("relato", "Paulo Moreira")
                    }
                )
            ), // 4
            new ClueNote("Quem s�o os Milicianos(Miliciano 3)", "Carlos Patroc�nio � um miliciano",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier("relato", "Carlos Patroc�nio")
                    }
                )
            ), // 5
            new ClueNote("Quais os cargos da policia dos Milicianos (Miliciano 3)", "Carlos Patroc�nio � o Coronel da Pol�cia do Rio de Janeiro",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "Carlos"),
                        new ClueIdentifier(null, "Patroc�nio"),
                        new ClueIdentifier(null, "Coronel")
                    }
                )
            ), // 6
            new ClueNote("Quais os cargos da policia dos Milicianos (Miliciano 2)", "Paulo Moreira � Primeiro Tenente da Pol�cia do Rio de Janeiro",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "Paulo"),
                        new ClueIdentifier(null, "Moreira"),
                        new ClueIdentifier(null, "Primeiro Tenente")
                    }
                )
            ), // 7
            new ClueNote("Quais os cargos da policia dos Milicianos (Miliciano 1)", "Joaquim Barbosa � Primeiro Sargento da Pol�cia do Rio de Janeiro",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "Joaquim"),
                        new ClueIdentifier(null, "Barbosa"),
                        new ClueIdentifier(null, "Primeiro Sargento")
                    }
                )
            ), // 8
            new ClueNote("Alguem amea�ou Helena?", "Carlos Patroc�nio amea�ou Helena Peres por telefone",
                new Clue(new List<ClueIdentifier>
                    {
                        new ClueIdentifier(null, "Carlos Patroc�nio"),
                        new ClueIdentifier(null, "medidas extemas|me despedia dos seus familiares")
                    }
                )
            ), // 9
        };
    }

    public override ChatEnum[] ChatToBeReleasedOnStart()
    {
        return new ChatEnum[1] { ChatEnum.patrocinio };
    }

    public override ChatEnum[] ChatToBeReleasedOnEnd()
    {
        return new ChatEnum[1] { ChatEnum.patrocinio };
    }

    public override ChatEnum[] ChatToBeReleasedBeforeEnd()
    {
        return new ChatEnum[1] { ChatEnum.patrocinio };
    }

    public override bool ShouldReleaseChatBeforeEnd()
    {
        if (this.released) return false;
        
        this.released = this.clueNotes[5].IsFound() || this.clueNotes[9].IsFound() || this.clueSolutions[2].IsFound();
        if (this.released) PlayerPrefs.SetInt(stageIdentifier + "_released", 1);

        return this.released;
    }
}
