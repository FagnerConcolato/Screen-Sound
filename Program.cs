

//List<string> ListasDasBandas = new List<string> {"Angra","Shaman","Almah" };    
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("angra", new List<int> { 10, 10, 4 });
bandasRegistradas.Add("Shaman", new List<int>());

void ExibirLogo()
{

    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀");

}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir as bandas e as notas");
    Console.WriteLine("Digite 5 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");
    Console.Write("\nDigite a sua Opção:");

    string opcao = Console.ReadLine()!;
    int opcaoNumerica = int.Parse(opcao);

    switch (opcaoNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ExibirListaDeBandas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            listarNotasDasBandas();
            break;
        case 5:
            MostrarAmediaDaBanda();
            break;
        case -1:
            Console.WriteLine("Saindo do programa");
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
}


ExibirOpcoesDoMenu();

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("\nDigite a sua Banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeDaBanda} cadastrada foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirListaDeBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo lista de bandas");

    //for (int i = 0; i < ListasDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda:{ ListasDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda:{banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar para o menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarUmaBanda()
{
    ExibirTituloDaOpcao("Avaliando as Bandas");
    Console.Write("\nDigite o nome de uma Banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Digite a nota que {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda{nomeDaBanda}: ");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} nao foi escontrada");
        Console.Write("digite uma tecla para voltar para o menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void listarNotasDasBandas()
{

    Console.Clear();
    ExibirTituloDaOpcao("Exibindo lista de Bandas e Notas");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($" banda: {banda}");

        foreach (int nota in bandasRegistradas[banda])
        {
            Console.WriteLine($"notas da banda:{nota}");

        }

        Console.WriteLine();

    }
}

void MostrarAmediaDaBanda()
{
    //verificar se abanda existe 
    //MostrarAmediaDaBanda a media 

    Console.Clear();
    ExibirTituloDaOpcao("Media da Banda");

    foreach (string banda in bandasRegistradas.Keys)

    {
     
        Console.WriteLine($"Banda: {banda}");
        List<int> notas = bandasRegistradas[banda];
        if (notas.Count > 0)
        {
            Console.WriteLine($"Media final {notas.Average()}");

        }
        else
        {

            Console.WriteLine("Nenhuma nota adicionada para essa banda");
               
        }

    }

    Console.Write("\nDigite uma tecla para voltar para o menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}


void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos);
}

