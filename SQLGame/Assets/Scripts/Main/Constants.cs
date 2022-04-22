public class Constants
{
    public const string AIName = "Lexa";
    public const string AIChat = "IAChat";

    public const string bossName = "Sr Patrocinio";
    public const string bossChat = "PatrocinioChat";

    public const string reporterName = "Reporter";
    public const string reporterChat = "Reporter";

    public const string friendName = "Vitor";
    public const string friendChat = "Friend";

    /* INITIAL TUTORIAL */
    public static readonly string[] initialTutorialStartInstructions = new string[] { "Ola, meu nome é Lexa, uma IA de auxilio com banco de dados",
                                                                                      "Pelos dados que tenho aqui, acho que voce me baixou para te ajudar com seu trabalho de BD né?",
                                                                                      "Ok. Primeiro vou te explicar o basico de como funciona esse computador ta bom?"};

    public static readonly string[] initialConfigButtonInstructions = new string[] { "Este botão serve para abrir a home (cá entre nós, ele só volta para o menu inicial)" };
    public static readonly string[] initialIAButtonInstructions = new string[] { "Este botão abre sua conversa diretamente comigo no aplicativo de mensagens, mas não iremos precisar nesse primeiro momento :)." };
    public static readonly string[] initialBDButtonInstructions = new string[] { "Este é o botão mais importante de todos.",
                                                                                 "Ele ta da acesso ao banco de dados."};
    public static readonly string[] initialCluesButtonInstructions = new string[] { "Aqui é onde nós iremos juntar todas as informações que descobrirmos",
                                                                                    "Vamos chamar isso de tela de pistas."};
    public static readonly string[] initialMessageButtonInstructions = new string[] { "E aqui é onde voce pode ver suas mensagens (qualquer semelhança entre o icone e um aplicativo que voce ja conhece é mera coincidencia rs)" };
    public static readonly string[] initialTutorialEndingInstructions = new string[] { "Agora, para começarmos, abra a tela de mensagens, você recebeu uma mensagem nova do seu amigo" };

    /* MESSAGE WINDOW */ 
    //MUDAR PARA TIRAR OS TRIGERS
    public static readonly string[] messageTutorialStartInstructions = new string[] { "Bem vindo ao aplicativo de mensagens. Você já deve conhecer mas não custa revisar."};
    public static readonly string[] messageTutorialContactInstructions = new string[] { "Essa é a tela de contatos, onde você pode ver suas mensagens com seus colegas.",
                                                                                        "Aqui você pode ver as mensagens trocadas com o pessoa selecionada e enviar novas mensagens para ela."};
    public static readonly string[] messageTutorialChatInstructions = new string[] { "No momento você só tem essa mensagem do Vitor, abra e veja o que ele quer com você.",
                                                                                     "Experimente conversar com seu amigo."};
    public static readonly string[] messageTutorialEndInstructions = new string[] { "Então ele te pediu ajuda no trabalho de banco de dados. Posso te ajudar com isso sim.",
                                                                                    "Primeiro vá para a tela de pistas, continuaremos a partir de lá."};

    /* CLUE WINDOW */
    public static readonly string[] clueWindowTutorialStartInstructions = new string[] { "Ola de novo.",
                                                                                    "Essa é a tela de pistas, aqui nós iremos anotar todas as pistas que temos no momento, além de voce poder checar dicas para as proximas pistas"};
    public static readonly string[] clueWindowClueInstructions = new string[] { "Esta é uma pista ainda não descoberta",
                                                                                "ela tem uma dica de como encontrar a pista real."};
    public static readonly string[] clueWindowFinalSolutionInstructions = new string[] { "Está é nossa solução final, ainda não sabemos nada sobre ela",
                                                                                         "Quando conseguirmos informações suficientes, a solução será mostrada e você deverá clicar nela para submeter seu resultado."};
    public static readonly string[] clueWindowTutorialEndingInstructions = new string[] { "Vamos ver essas dicas: 'Qual o salário do suspeito?' e 'Quanto o suspeito recebeu em março?'",
                                                                                          "Bom, vamos ver o banco pra tentar descobrir essas informações"};

    /* TABLE WINDOW */
    public static readonly string[] tableWindowTutorialStartInstructions = new string[] { "Este aplicativo permite que você consulte dados do banco de dados em questão." };
    public static readonly string[] tableWindowTutorialSideBarInstructions = new string[] { "Esta barra lateral mostra todas as tabelas que tem no banco de dados e quais seus campos.",
                                                                                            "É uma ótima forma de você saber como montar as buscas para solucionar o problema."};
    public static readonly string[] tableWindowTutorialQueryBoxInstructions = new string[] { "Este campo de texto permite que você realize buscas dentro do banco de dados, através do SQL." };
    public static readonly string[] tableWindowTutorialButtonInstructions = new string[] { "E este botão submete a busca digitada para o banco, fazendo com que os dados sejam listados na área abaixo." };
    public static readonly string[] tableWindowTutorialEndingInstructions = new string[] { "Experimente olhar os dados da tabela Funcionarios e da tabela Gastos.",
                                                                                        "A consulta pode ser feita usando SELECT * FROM Funcionarios;",
                                                                                        "Tente encontrar um 'suspeito', alguem que tenha gastado mais do que tenha recebido, por exemplo.",
                                                                                        "Para que a pista seja encontrada e registrada na tela de pistas, use uma consulta que retorne UMA ÚNICA LINHA",
                                                                                        "Isso pode ser feito com a consulta SELECT * FROM Funcionarios WHERE matricula = 'XXXXX'; para trazer apenas o Funcionario de matricula XXXXX",
                                                                                        "Boa sorte!"};
}

