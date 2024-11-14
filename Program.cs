
using System.Runtime.Serialization.Formatters;

Dictionary<string, List<double>> bandasRegistradas = new Dictionary<string, List<double>>();
bandasRegistradas.Add("ANGRA", new List<double> { 10, 10, 4});
bandasRegistradas.Add("SHAMAN", new List<double>());

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
    Console.WriteLine("Digite 6 para sair");
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
        case 6:
            Console.WriteLine("\nSaindo do programa");
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
    Console.Write("\nDigite o nome da sua Banda: ");
    string nomeDaBanda = Console.ReadLine()!.ToUpper();

    bandasRegistradas.Add(nomeDaBanda, new List<double>());
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirListaDeBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo lista de bandas");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda:{banda}");
    }
    Console.Write("\nDigite uma tecla para voltar para o menu principal: ");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliando as Bandas");
    Console.Write("\nDigite o nome de uma Banda: ");
    string nomeDaBanda = Console.ReadLine()!.ToUpper();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Digite a nota que {nomeDaBanda} merece: ");
        double nota = double.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}: ");
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

        foreach (double nota in bandasRegistradas[banda])
        {
            Console.WriteLine($"notas da banda:{nota}");

        }

        Console.WriteLine();

    }
    LimparEvoltarParaAsOpçoesDoMenu();
}

void MostrarAmediaDaBanda()
{
    //verificar se abanda existe 
    //MostrarAmediaDaBanda a media 

    Console.Clear();
    ExibirTituloDaOpcao("Exibindo a Média por Banda!");
    Console.WriteLine("Digite o Nome da banda para ver a sua respectiva média:");
    string nomeDaBanda = Console.ReadLine()!.ToUpper();

    if (bandasRegistradas.ContainsKey(nomeDaBanda) && bandasRegistradas[nomeDaBanda].Count>0)
    {

        List<double> NotasDasBandas = bandasRegistradas[nomeDaBanda];
        double media = NotasDasBandas.Average();
        Console.WriteLine($"A média da banda: {nomeDaBanda} é :{media}");
        LimparEvoltarParaAsOpçoesDoMenu();

    }
    else if(bandasRegistradas.ContainsKey(nomeDaBanda) && bandasRegistradas[nomeDaBanda].Count==0)
    {
        Console.WriteLine("Nenhuma nota foi adicionada para Essa Banda");
        LimparEvoltarParaAsOpçoesDoMenu();
    }
    
    else
    {
        Console.WriteLine("Essa Banda nao foi cadastradas");
        LimparEvoltarParaAsOpçoesDoMenu();
    }

   
    

    //foreach (string banda in bandasRegistradas.Keys)

    //{
     
    //    Console.WriteLine($"Banda: {banda}");
    //    List<double> notas = bandasRegistradas[banda];
    //    if (notas.Count > 0)
    //    {
    //        Console.WriteLine($"Media final {notas.Average()}");

    //    }
    //    else
    //    {

    //        Console.WriteLine("Nenhuma nota adicionada para essa banda");
               
    //    }

    //}

    //Console.Write("\nDigite uma tecla para voltar para o menu");
    //Console.ReadKey();
    //Console.Cle

}


void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos);
}

void LimparEvoltarParaAsOpçoesDoMenu()
{
    Console.Write("digite uma tecla para voltar para o menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}
