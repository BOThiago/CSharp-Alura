using System.Runtime.InteropServices;

// Lista das bandas.
Dictionary<string, List<int>> bandsRepository = new Dictionary<string, List<int>>();

// Define bandas e notas por padrão
void DefaultBands()
{
    bandsRepository.Add("Queen", new List<int> { 10, 10, 10 });
    bandsRepository.Add("The Beatles", new List<int> { 10, 10, 10 });
    bandsRepository.Add("Imagine Dragons", new List<int> { 10, 10, 10 });
    bandsRepository.Add("Twenty One Pilots", new List<int> { 10, 10, 10 });
}
DefaultBands();

// Exibe as Boas-Vindas.
void Welcome()
{
    Console.WriteLine(@"
    
    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

    ");
}

// Exibe o título de uma área da aplicação.
void optionTile(String title)
{
    Console.Clear();
    int numberOfLetters = title.Length;
    string decoration = string.Empty.PadLeft(numberOfLetters, '*');
    Console.WriteLine(decoration);
    Console.WriteLine(title);
    Console.WriteLine(decoration + "\n");
}

// Coleta a Opção do Usuário e verifica se é valída.
int GetOption()
{
    int numeroDaOpcao;

    while (true)
    {
        Console.Write("\nSelecione uma opção: ");
        string opcaoEscolhida = Console.ReadLine()!;

        if (int.TryParse(opcaoEscolhida, out numeroDaOpcao))
        {
            return numeroDaOpcao;
        }
        else
        {
            Console.WriteLine("Opção inválida. Digite um número válido.");
        }
    }
}

//Menu Options
void MenuOptions()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda.");
    Console.WriteLine("Digte 2 para mostrar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média de uma banda.");
    Console.WriteLine("Digite 0 para sair");
}

//Mostra o menu.
void Menu()
{
    Console.Clear();
    Welcome();
    MenuOptions();

    // Mostra a opção escolhida.
    switch (GetOption())
    {
        case 1:
            CreateBand();
            break;

        case 2:
            ViewBands();
            break;

        case 3:
            RateBands();
            break;

        case 4:
            RateAvarege();
            break;

        case 0:
            optionTile("Você saiu da aplicação!");
            break;
    }
}
Menu();

// Salva a banda na lista de bandas.
Dictionary<string, List<int>> saveBand(string bandName)
{
    // Adicione a banda à lista
    bandsRepository.Add(bandName, new List<int>());

    return bandsRepository;
}

// Cria uma nova banda e adiciona na lista.
void CreateBand()
{
    Console.Clear();

    optionTile("Registro de Bandas");

    Console.Write("Digite o nome da banda que deseja registrar: ");

    string bandName = Console.ReadLine()!;
    saveBand(bandName);

    Console.WriteLine($"A banda {bandName} foi registrada com sucesso !");

    Thread.Sleep(2000);

    Console.Clear();

    Menu();
}

// Lista as bandas registradas.
void ViewBands()
{
    optionTile("Exibindo Bandas");

    foreach (string banda in bandsRepository.Keys)
    {
        Console.WriteLine($"{banda}");
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

// Verifica se a nota é valida.
void VerifyNote(string bandName)
{
    Console.Write($"Qual a nota que a banda {bandName} merece? ");
    string nota = Console.ReadLine()!;

    if (int.TryParse(nota, out int numeroDaOpcao))
    {
        if (numeroDaOpcao >= 0 && numeroDaOpcao <= 10)
        {
            bandsRepository[bandName].Add(numeroDaOpcao);
            Console.WriteLine($"Sua nota {numeroDaOpcao} foi adicionada à banda {bandName}!");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("Opção inválida. Digite um número válido entre 0 e 10.");
        }
    }
    else
    {
        Console.WriteLine("Opção inválida. Digite um número válido.");
    }
}

// Avaliação das Bandas
void RateBands()
{
    Console.Clear();

    void OptionsRate()
    {
        Console.WriteLine("\nDigite 1 avaliar outra banda.");
        Console.WriteLine("Digte 2 para voltar ao menu.");
        Console.WriteLine("Digite 0 para sair");
    }

    void RateOptions()
    {
        Console.Clear();
        Welcome();
        OptionsRate();

        // Mostra a opção escolhida.
        switch (GetOption())
        {
            case 1:
                RateBands();
                break;

            case 2:
                Menu();
                break;

            case 0:
                optionTile("Você saiu da aplicação!");
                break;
        }
    }

    optionTile("Avaliar Banda");
    
    Console.Write("Digite o nome da banda que deseja avaliar: ");

    string bandName = Console.ReadLine()!;

    // Verifica se a banda existe, se ela não existir adiciona, e avalia.
    if (!bandsRepository.ContainsKey(bandName))
    {
        saveBand(bandName);
    }

    VerifyNote(bandName);

    RateOptions();
}

// Calcula Média da Banda.
void RateCalc(string bandName)
{
    List<int> RateValues = bandsRepository[bandName];

    double avarage = RateValues.Average();
    Console.WriteLine($"A média da banda {bandName} é {avarage}!");
    Thread.Sleep(2000);
}


// Mostra a Média de uma banda escolhida, se não existir ela cria e você atribuirá uma nota.
void RateAvarege()
{
    Console.Clear();

    optionTile("Visualize a média de uma banda!");

    Console.Write("Digite o nome da banda que deseja ver a média: ");

    string bandName = Console.ReadLine()!;

    // Verifica se a banda existe, se ela não existir adiciona e pede uma avaliação.
    if (!bandsRepository.ContainsKey(bandName))
    {
        saveBand(bandName);
        VerifyNote(bandName);
        RateCalc(bandName);

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        Menu();
    } else
    {
        RateCalc(bandName);

        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}