using System.Globalization;

class Produto
{
    public string Nome { get; set; }
    public int Codigo { get; set; }
    public string Validade { get; set; }
    public string Entrada { get; set; }
    public double Estoque { get; set; }
}
class Program
{
    static List<Produto> produtos = new List<Produto>();
    static void Main(string[] args)
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar:");
            Console.WriteLine("2. Mostra produtos:");
            Console.WriteLine("3. Procurar produto:");
            Console.WriteLine("4. apagar produto:");
            Console.WriteLine("5. Sair:");
            Console.WriteLine("Escolha uma opcao:");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Nome do produto");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Codigo do produto:");
                    if (int.TryParse(Console.ReadLine(), out int codigo))
                    {
                        Console.WriteLine("Validade do produto:");
                        string validade = Console.ReadLine();
                        Console.WriteLine("Entrada do produto:");
                        string entrada = Console.ReadLine();
                        Console.WriteLine("Estoque do produto");
                        if (double.TryParse(Console.ReadLine(), out double estoque))
                        {
                            CadastrarProduto(nome, codigo, validade, entrada, estoque);
                        }

                        else
                        {
                            Console.WriteLine("Entrada invalida");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada invalida");
                    }


                    break;
                case "2":
                    MostrarProduto();
                    break;
                case "3":
                    OpcaoProcurarProduto();
                    break;
                case "4":
                    Console.Write("Digite o codigo do produto que deseja excluir :");
                    if(int.TryParse(Console.ReadLine(),out int codigoRemover))
                    {
                        RemoverProduto(codigoRemover);
                    }
                    else
                    {
                        Console.Write("Codigo invalido");
                    }
                    break;
                case "5":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    Console.WriteLine("Tente novamente");
                    break;

            }
        }
    }
    static void CadastrarProduto(string nome, int codigo, string validade, string entrada, double estoque)
    {
        produtos.Add(new Produto
        {
            Nome = nome,
            Codigo = codigo,
            Validade = validade,
            Entrada = entrada,
            Estoque = estoque
        });
        Console.WriteLine("Produto cadastrado com sucesso");
    }
    static void MostrarProduto()
    {
        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto encontrado");
            return;
        }
        Console.WriteLine("Produtos Cadastrados:");
        Console.WriteLine("----------------------------------");
        foreach (Produto produto in produtos)
        {
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Codigo: {produto.Codigo}");
            Console.WriteLine($"Validade: {produto.Validade}");
            Console.WriteLine($"Entrada: {produto.Entrada}");
            Console.WriteLine($"Estoque {produto.Estoque}");
            Console.WriteLine("----------------------------------");
        }
    }
    static void OpcaoProcurarProduto()
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\nProcurar Produto");
            Console.WriteLine("1. Procurar por Codigo:");
            Console.WriteLine("2. Procurar por Nome:");
            Console.WriteLine("3. Procurar por validade:");
            Console.WriteLine("4. Procurar por periodo:");
            Console.WriteLine("5. Volta ao menu anterior:");
            Console.WriteLine("Escolha uma opcao:");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o codigo :");

                    if (int.TryParse(Console.ReadLine(), out int codigoProcurado))
                    {
                        ProcurarCodigo(codigoProcurado);
                    }
                    else
                    {
                        Console.WriteLine("Entrada invalida");
                    }

                    break;
                case "2":
                    Console.Write("Digite o nome :");
                    string nomeProcurado = Console.ReadLine();
                    ProcurarNome(nomeProcurado);


                    break;
                case "3":
                    Console.Write("Digite a validade :");
                    string validadeProcurada = Console.ReadLine();
                    ProcurarValidade(validadeProcurada);
                    break;
                case "4":
                    Console.Write("Digite a data inicial do periodo:");
                    if(DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime diaInicial))
                    {
                        Console.Write("Digite a data final do periodo:");
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime diaFinal))
                        {
                            procurarPeriodo(diaInicial, diaFinal);

                        }
                        else
                        {
                            Console.WriteLine("data final inserida errada");
                        }
                    }
                    else
                    {
                        Console.WriteLine("data inicial inserida errada");
                    }
                    break;
                case "5":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    break;
            }
        }
    }
    static void ProcurarCodigo(int codigo)
    {
        Produto produtoEncontrado = produtos.Find(produto => produto.Codigo == codigo);
        if (produtoEncontrado != null)
        {
            Console.WriteLine("Produto Encontrado");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
            Console.WriteLine($"Codigo: {produtoEncontrado.Codigo}");
            Console.WriteLine($"Validade: {produtoEncontrado.Validade}");
            Console.WriteLine($"Entrada: {produtoEncontrado.Entrada}");
            Console.WriteLine($"Estoque: {produtoEncontrado.Estoque}");
        }
        else
        {
            Console.WriteLine("Produto nao encontrado");
        }
    }
    static void ProcurarNome(string nome)
    {
        Produto produtoEncontrado = produtos.Find(produto => produto.Nome.Equals
        (nome, StringComparison.OrdinalIgnoreCase));
        if (produtoEncontrado != null)
        {
            Console.WriteLine("Produto Encontrado");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
            Console.WriteLine($"Codigo: {produtoEncontrado.Codigo}");
            Console.WriteLine($"Validade: {produtoEncontrado.Validade}");
            Console.WriteLine($"Entrada: {produtoEncontrado.Entrada}");
            Console.WriteLine($"Estoque: {produtoEncontrado.Estoque}");
        }
        else
        {
            Console.WriteLine("Produto nao encontrado");
        }
    }
    static void ProcurarValidade(string validade)
    {
        Produto produtoEncontrado = produtos.Find(produto => produto.Validade.Equals
        (validade, StringComparison.OrdinalIgnoreCase));
        if (produtoEncontrado != null)
        {
            Console.WriteLine("Produto Encontrado");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
            Console.WriteLine($"Codigo: {produtoEncontrado.Codigo}");
            Console.WriteLine($"Validade: {produtoEncontrado.Validade}");
            Console.WriteLine($"Entrada: {produtoEncontrado.Entrada}");
            Console.WriteLine($"Estoque: {produtoEncontrado.Estoque}");
        }
        else
        {
            Console.WriteLine("Produto nao encontrado");
        }
    }
    static void procurarPeriodo(DateTime diaInicial,DateTime diaFinal)
    {
        List<Produto> produtosEncontrados = produtos.FindAll(produtos =>
        {
            DateTime dataValidade;
            if (DateTime.TryParseExact(produtos.Validade, "dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out dataValidade))
            {
                return dataValidade >= diaInicial && dataValidade <= diaFinal;
            }
            return false;
        });
        if(produtosEncontrados.Count>0)
        {
            Console.WriteLine("Produtos Encontrados no período:");
            Console.WriteLine($"De {diaInicial :dd/MM/yyyy} a {diaFinal :dd/MM/yyyy}");
            Console.WriteLine("------------------------------------");
            foreach (Produto produtoEncontrado in produtosEncontrados)
            {
                Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
                Console.WriteLine($"Codigo: {produtoEncontrado.Codigo}");
                Console.WriteLine($"Validade: {produtoEncontrado.Validade}");
                Console.WriteLine($"Entrada: {produtoEncontrado.Entrada}");
                Console.WriteLine($"Estoque: {produtoEncontrado.Estoque}");
                Console.WriteLine("------------------------------------");
            }
        }
        else
        {
            Console.WriteLine($"Nenhum produto encontrado no período de {diaInicial:dd/MM/yyyy} a {diaFinal:dd/MM/yyyy}.");
        }
    }
    static void RemoverProduto(int codigo)
    {
        Produto produtoParaRemover = produtos.Find(produto => produto.Codigo == codigo);
        if( produtoParaRemover != null )
        {
            produtos.Remove(produtoParaRemover);
            Console.WriteLine("Produto removido com sucesso");
        }
        else
        {
            Console.WriteLine("Produto nao encontrado");
            Console.WriteLine("Falha ao remover o produto");
        }
    }
}