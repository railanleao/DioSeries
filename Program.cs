using DioSeries.Model;
using DioSeries.Model.EnumClass;
using static System.Console;

SeriesRepositorio repositorio = new SeriesRepositorio();

string opcaoDoUsuario = ObterOpcaoUsuario();
while(opcaoDoUsuario.ToUpper() != "X")
{
    switch(opcaoDoUsuario)
    {
        case "1":
            ListarSeries();
            break;
        case "2":
            InserirSerie();
            break;
        case "3":
            AtualizarSerie();
            break;
        case "4":
            ExcluirSerie();
            break;
        case "5":
            VisualizarSerie();
            break;
        case "C": 
            Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException(); 
    }
            opcaoDoUsuario = ObterOpcaoUsuario();
}

void ListarSeries()
{
    WriteLine("Listar Séries: ");

    var lista = repositorio.Lista();

    if (lista.Count == 0)
    {
        WriteLine("Nenhuma série cadastrada.");
        return;
    }
     
    foreach (var serie in lista)
    {
        var excluido = serie.retornaExcluido();

        WriteLine($"ID: {serie.retornaId()} : {serie.retornaTitulo()} - {(excluido ? "Excluído" : "")}"); 
    }
}

void InserirSerie()
{
    WriteLine("Insira nova série: ");
    //para saber o género
    foreach(int genero in Enum.GetValues(typeof(EGenero)))
    {
        WriteLine($"{genero} - {Enum.GetName(typeof(EGenero),genero)}");
    }
    Write("Digite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(ReadLine());
    Write("Digite o título da série: ");
    string? entradaTitulo = ReadLine();
    Write("Entre com o ano de estreia: ");
    int entradaAnoEstreia = int.Parse(ReadLine());
    Write("Digite a descrição da série: ");
    string? entradaDescricao = ReadLine();

    Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero:(EGenero)entradaGenero,
                                titulo: entradaTitulo, descricao: entradaDescricao, ano: entradaAnoEstreia);
    repositorio.Insere(novaSerie);
}

void AtualizarSerie()
{
    WriteLine("Digite o id da série: ");
    int entradaId = int.Parse(ReadLine());
    foreach(int genero in Enum.GetValues(typeof(EGenero)))
    {
        WriteLine($"{genero} - {Enum.GetName(typeof(EGenero),genero)}");
    }
    Write("Digite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(ReadLine());
    Write("Digite o título da série: ");
    string? entradaTitulo = ReadLine();
    Write("Entre com o ano de estreia: ");
    int entradaAnoEstreia = int.Parse(ReadLine());
    Write("Digite a descrição da série: ");
    string? entradaDescricao = ReadLine();

    Serie atualizarSerie = new Serie( id: entradaId, genero:(EGenero)entradaGenero,
                                    titulo: entradaTitulo,descricao: entradaDescricao, ano: entradaAnoEstreia);
    repositorio.Atualiza(entradaId, atualizarSerie);
}

void VisualizarSerie()
{
    WriteLine("Entre com o id da série: ");
    int indiceDaSerie = int.Parse(ReadLine());

    var serie = repositorio.RetornaPorId(indiceDaSerie);

    WriteLine(serie);
}
void ExcluirSerie()
{
    Write("Digite o id da série que deseja excluir: ");
    int entradaIdExcluir = int.Parse(ReadLine());

    repositorio.Exclui(entradaIdExcluir);
}
static string ObterOpcaoUsuario()
{
        WriteLine();
        WriteLine("DioSerie sua lista de séries!");
        WriteLine("Informe sua opção:");

        WriteLine("1- Listar Séries"); 
        WriteLine("2- Inserir Nova Série");
        WriteLine("3- AtualizarSerie");
        WriteLine("4- ExcluirSerie");
        WriteLine("5- VisualizarSerie");
        WriteLine("C- Limpar Tela");
        WriteLine("X- Sair");
        WriteLine();

            string opcaoDoUsuario = ReadLine().ToUpper();
                
        WriteLine();
            return opcaoDoUsuario;
}