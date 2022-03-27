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

    public static readonly string[] initialTutorialStartInstructions = new string[] { "Ola, meu nome é Lexa, uma IA de auxilio com banco de dados",
                                                                                      "Pelos dados que tenho aqui, acho que voce me baixou para te ajudar com seu trabalho de BD né?",
                                                                                      "Ok. Primeiro vou te explicar o basico de como funciona esse computador ta bom?"};

    public static readonly string[] initialConfigButtonInstructions = new string[] { "Este botão serve para abrir a home (cá entre nós, ele só volta para o menu inicial)" };

    public static readonly string[] initialIAButtonInstructions = new string[] { "Este botão abre sua conversa diretamente comigo :)." };

    public static readonly string[] initialBDButtonInstructions = new string[] { "Este é o botão mais importante de todos.",
                                                                                 "Ele ta da acesso ao banco de dados."};

    public static readonly string[] initialCluesButtonInstructions = new string[] { "Aqui é onde nós iremos juntar todas as informações que descobrirmos",
                                                                                    "Vamos chamar isso de tela de pistas."};

    public static readonly string[] initialMessageButtonInstructions = new string[] { "E aqui é onde voce pode ver suas mensagens (qualquer semelhança entre o icone e um aplicativo que voce ja conhece é mera coincidencia rs)" };

    public static readonly string[] initialTutorialEndingInstructions = new string[] { "Agora, para começarmos, abra a tela de mensagens, você recebeu uma mensagem nova do seu amigo" };

    /* MESSAGE WINDOW */ 
    public static readonly string[] messageTutorialStartInstructions = new string[] { "Bem vindo ao aplicativo de mensagens. Você já deve conhecer mas não custa revisar."};
    public static readonly string[] messageTutorialContactInstructions = new string[] { "Essa é a tela de contatos, onde você pode ver suas mensagens com seus colegas.",
                                                                                        "No momento você só tem essa mensagem do Vitor, abra e veja o que ele quer com você."};
    public static readonly string[] messageTutorialChatInstructions = new string[] { "Aqui você pode ver as mensagens trocadas com o pessoa selecionada e enviar novas mensagens para ela." };
    public static readonly string[] messageTutorialEndInstructions = new string[] { "Experimente conversar com seu amigo.",
                                                                                    "Então ele te pediu ajuda no trabalho de banco de dados. Posso te ajudar com isso sim.",
                                                                                    "Primeiro vá para a tela de pistas, continuaremos a partir de lá."}; //Exibir esse texto no final da conversa com o Vitor

    /* CLUE WINDOW */
    public static readonly string[] clueWindowTutorialStartInstructions = new string[] { "Ola de novo.",
                                                                                    "Essa é a tela de pistas, aqui nós iremos anotar todas as pistas que temos no momento, além de voce poder checar dicas para as proximas pistas"};

    public static readonly string[] clueWindowClueInstructions = new string[] { "Esta é uma pista ainda não descoberta",
                                                                                "ela tem uma dica de como encontrar a pista real."};

    public static readonly string[] clueWindowFinalSolutionInstructions = new string[] { "Está é nossa solução final, ainda não sabemos nada sobre ela",
                                                                                         "Quando conseguirmos informações suficientes, a solução será mostrada"};

    public static readonly string[] clueWindowTutorialEndingInstructions = new string[] { "Vamos ver essas dicas: 'Qual o salário do suspeito?' e 'Quanto o suspeito recebeu em março?'",
                                                                                          "Bom, vamos ver o banco pra tentar descobrir essas informações"};

    public static readonly string[] dbWindowTutorialStartInstructions = new string[] { "Agora que estamos na tela de pistas irei te explicar algumas coisas que acredito que voce já saiba, pois voce ja deve ter tentado começar seu trabalho ne :)" };

    public static readonly string[] dbWindowSearchInstructions = new string[] { "Esta é a barra de busca, nela voce poderá executar os comandos SQL para tentar encontrar as pistas" };

    public static readonly string[] dbWindowTreeInstructions = new string[] { "Aqui temos 2 coisas importantes",
                                                                              "1 - a arvore do banco na esquerda: nela temos a visualização de todas as tabelas do banco, bem como as colunas de cada tabela",
                                                                              "2 - Area da tabela na direita: esta é a area onde irá aparecer a tabela quando voce realizar uma busca",
                                                                              "AH! Uma coisa importante, para que uma pista seja computada na nossa tela de pistas, vc precisa mostrar na tabela apenas a linha com a pista!"};

    public static readonly string[] dbWindowTutorialEndingInstructions = new string[] { "Bom, vamos ao que importa, nossas dicas eram: 'Qual o salário do suspeito' e 'Quanto o suspeito recebeu em março'",
                                                                                        "hmm, essas pistas são muito genéricas, normalmente não é assim :(",
                                                                                        "Como não é assim, vou te dar uma dica muito boa :D. Voce precisa encontrar qual o funcionário que tem o salario menor do que gastou em março.",
                                                                                        "Use as querys: 'select * from Funcionarios;' e 'select * from Gastos;' para podere comprar",
                                                                                        "Quando souber qual o funcionario, faça o seguinte: 'select * from Funcionarios where matricula = xxxx;' o parametro Where fará vc pegar apenas a linha correta, mas vc já sabia disso né ;)"};
}

