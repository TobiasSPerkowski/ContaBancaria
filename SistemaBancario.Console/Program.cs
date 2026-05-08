using ContaBancaria.Console.Models;
using ContaBancaria.Console.Controllers;
using System.Runtime.CompilerServices;

// ==== MAIN ====

ContaController banco = new();

while (true)
{
    ExibirMenu();

    Console.Write("Digite a operação desejada: ");
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Cadastrar();
            break;

        case "2":
            Atualizar();
            break;

        case "3":
            Deletar();
            break;

        case "4":
            Procurar();
            break;

        case "5":
            Listar();
            break;
        
        case "6":
            Sacar();
            break;

        case "7":
            Depositar();
            break;

        case "8":
            Transferir();
            break;

        case "0":
            Console.WriteLine("\nAté mais!\n");
            Environment.Exit(1);
            break;

        default:
            Console.WriteLine("\nOpção inválida.");
            break;
    }

    Console.WriteLine("\nPressione ENTER para continuar...");
    Console.ReadLine();
    Console.Clear();
}

// ==== FUNCOES AUXILIARES ====

void ExibirMenu()
{
    Console.WriteLine("==== BANCO ====");
    Console.WriteLine("1 - Cadastrar conta");
    Console.WriteLine("2 - Atualizar conta");
    Console.WriteLine("3 - Deletar conta");
    Console.WriteLine("4 - Procurar conta");
    Console.WriteLine("5 - Listar contas");
    Console.WriteLine("6 - Sacar");
    Console.WriteLine("7 - Depositar");
    Console.WriteLine("8 - Transferir");
    Console.WriteLine("0 - Sair");
}

void Cadastrar()
{
    Console.Clear();
    Console.WriteLine("=== Cadastro de Conta ===");
    Console.WriteLine("1 - Conta corrente");
    Console.WriteLine("2 - Conta poupança");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha o tipo de conta: ");
    string? opcao = Console.ReadLine();

    if (opcao == "0") return;

    if (opcao != "1" && opcao != "2")
    {
        Console.WriteLine("\nOpção inválida.");
        return;
    }

    Conta conta;

    try
    {
        Console.Write("Digite o nome do titular: ");
        string nome = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception(); // vai para o catch

        Console.Write("Digite o número da agência: ");

        int agencia = Convert.ToInt32(Console.ReadLine());

        if (agencia <= 0)
            throw new Exception();

        if (opcao == "1")
        {
            Console.Write("Digite o limite: ");
            decimal limite = Convert.ToDecimal(Console.ReadLine());
            conta = new ContaCorrente
            (
                agencia: agencia,
                titular: nome,
                limite: limite
            );
        }
        else
        {
            Console.Write("Digite o aniversário: ");
            int aniver = Convert.ToInt32(Console.ReadLine());

            if (aniver < 1 || aniver > 31)
                throw new Exception();

            conta = new ContaPoupanca
            (
                agencia: agencia,
                titular: nome,
                aniversario: aniver
            );   
        }

        if (banco.Cadastrar(conta))
            Console.WriteLine("\nConta cadastrada com sucesso!");
        else
            Console.WriteLine("\nErro ao cadastrar conta.");
    }
    catch
    {
        Console.WriteLine("\nErro: Valor inválido.");
    }
}

void Atualizar()
{
    Console.Clear();
    Console.WriteLine("=== Atualização de Conta ===");
    Console.WriteLine("1 - Conta corrente");
    Console.WriteLine("2 - Conta poupança");
    Console.WriteLine("0 - Sair");
    Console.Write("Digite o tipo da conta que deseja atualizar: ");
    string? opcao = Console.ReadLine();

    if (opcao == "0") return;

    if (opcao != "1" && opcao != "2")
    {
        Console.WriteLine("\nOpção inválida.");
        return;
    }

    Conta? conta;

    Console.Write("Digite o número da conta que deseja atualizar: ");
    try
    {
        int numero = Convert.ToInt32(Console.ReadLine());

        conta = banco.ProcurarPorNumero(numero);
        if (conta == null)
        {
            Console.WriteLine("\nConta não encontrada.");
            return;
        }

        Console.WriteLine($"\n{conta}\n");

        Console.Write("Digite o novo titular: ");
        string titular = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(titular))
            throw new Exception(); // vai para o catch

        Console.Write("Digite a nova agência: ");
        int agencia = Convert.ToInt32(Console.ReadLine());

        if (agencia <= 0)
            throw new Exception();

        if (opcao == "1")
        {
            Console.Write("Digite o novo limite: ");
            decimal limite = Convert.ToDecimal(Console.ReadLine());
            conta = new ContaCorrente
            (
                numero: numero,
                agencia: agencia,
                titular: titular,
                limite: limite
            );
        }
        else
        {
            Console.Write("Digite o novo aniversário: ");
            int aniver = Convert.ToInt32(Console.ReadLine());

            if (aniver < 1 || aniver > 31)
                throw new Exception();

            conta = new ContaPoupanca
            (
                numero: numero,
                agencia: agencia,
                titular: titular,
                aniversario: aniver
            ); 
        }

        if (banco.Atualizar(conta))
            Console.WriteLine("\nConta atualizada com sucesso!");
        else
            Console.WriteLine("\nErro ao atualizar conta.");
    }
    catch
    {
        Console.WriteLine("\nErro: Valor inválido.");
    }
}

void Deletar()
{
    Console.Clear();
    Console.WriteLine("=== Deletar Conta ===");
    Console.Write("Digite o número da conta que deseja deletar: ");
    try
    {
        int numero = Convert.ToInt32(Console.ReadLine());

        Conta? conta = banco.ProcurarPorNumero(numero);
        if (conta == null)
        {
            Console.WriteLine("\nConta não encontrada.");
            return;
        }

        Console.WriteLine($"\n{conta}\n");
        Console.Write("Tem certeza que deseja deletar essa conta? (s/n): ");
        string? confirmacao = Console.ReadLine();

        if (confirmacao == "s")
            if (banco.Deletar(numero))
                Console.WriteLine("\nConta deletada com sucesso.");
            else
                Console.WriteLine("\nErro ao deletar conta.");
        else if (confirmacao == "n")
            Console.WriteLine("\nA conta não será deletada.");
        else
            throw new Exception(); // vai para o catch
    }
    catch
    {
        Console.WriteLine("\nErro: Valor inválido.");
    }
}

void Procurar()
{
    Console.Clear();
    Console.WriteLine("=== Procurar Conta ===");
    Console.Write("Digite o número da conta que deseja procurar: ");
    try
    {
        int numero = Convert.ToInt32(Console.ReadLine());

        Conta? conta = banco.ProcurarPorNumero(numero);
        if (conta == null)
        {
            Console.WriteLine("\nConta não encontrada.");
            return;
        }

        Console.WriteLine($"\n{conta}\n");
    }
    catch
    {
        Console.WriteLine("\nErro: Valor inválido.");
    }
}

void Listar()
{
    Console.Clear();
    Console.WriteLine("=== Lista de Contas ===");

    int i = 0;
    foreach (Conta c in banco.ListarTodas())
    {
        Console.WriteLine($"\n{c}\n");
        Console.WriteLine("----------------");
        i++;
    }

    if (i == 0)
        Console.WriteLine("\nNenhuma conta cadastrada.");
}

void Sacar()
{
    Console.Clear();
    Console.WriteLine("=== Saque ===");
    Console.Write("Digite o número da conta da qual deseja sacar: ");
    try
    {
        int numero = Convert.ToInt32(Console.ReadLine());

        Conta? conta = banco.ProcurarPorNumero(numero);
        if (conta == null)
        {
            Console.WriteLine("\nConta não encontrada.");
            return;
        }

        Console.WriteLine($"\n{conta}\n");

        Console.Write("Digite o valor que deseja sacar: ");
        decimal valor = Convert.ToDecimal(Console.ReadLine());

        if (banco.Sacar(numero, valor))
            Console.WriteLine("\nSaque efetuado com sucesso!");
        else
            Console.WriteLine("\nErro ao efetuar saque.");
    }
    catch
    {
        Console.WriteLine("\nErro: Valor inválido.");
    }
}

void Depositar()
{
    Console.Clear();
    Console.WriteLine("=== Depósito ===");
    Console.Write("Digite o número da conta na qual deseja depositar: ");
    try
    {
        int numero = Convert.ToInt32(Console.ReadLine());

        Conta? conta = banco.ProcurarPorNumero(numero);
        if (conta == null)
        {
            Console.WriteLine("\nConta não encontrada.");
            return;
        }

        Console.WriteLine($"\n{conta}\n");

        Console.Write("Digite o valor que deseja depositar: ");
        decimal valor = Convert.ToDecimal(Console.ReadLine());

        if (banco.Depositar(numero, valor))
            Console.WriteLine("\nDepósito efetuado com sucesso!");
        else
            Console.WriteLine("\nErro ao efetuar depósito.");
    }
    catch
    {
        Console.WriteLine("\nErro: Valor inválido.");
    }
}

void Transferir()
{
    Console.Clear();
    Console.WriteLine("=== Transferência ===");
    Console.Write("Digite o número da conta origem: ");
    try
    {
        int numOrigem = Convert.ToInt32(Console.ReadLine());

        Conta? cOrigem = banco.ProcurarPorNumero(numOrigem);
        if (cOrigem == null)
        {
            Console.WriteLine("\nConta não encontrada.");
            return;
        }

        Console.WriteLine($"\n{cOrigem}\n");

        Console.Write("Digite o número da conta destino: ");

        int numDestino = Convert.ToInt32(Console.ReadLine());

        Conta? cDestino = banco.ProcurarPorNumero(numDestino);
        if (cDestino == null)
        {
            Console.WriteLine("\nConta não encontrada.");
            return;
        }

        Console.WriteLine($"\n{cDestino}\n");

        Console.Write("Digite o valor que deseja transferir: ");
        decimal valor = Convert.ToDecimal(Console.ReadLine());

        if (banco.Transferir(numOrigem, numDestino, valor))
            Console.WriteLine("\nTransferência efetuada com sucesso!");
        else
            Console.WriteLine("\nErro ao efetuar transferência.");
    }
    catch
    {
        Console.WriteLine("\nErro: Valor inválido.");
    }
}