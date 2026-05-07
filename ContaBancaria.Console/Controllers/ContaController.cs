using ContaBancaria.Console.Repositories;
using ContaBancaria.Console.Models;

namespace ContaBancaria.Console.Controllers;

public class ContaController : IContaRepository
{
    private int proxNum = 1;
    private List<Conta> contas = new();

    public Conta? ProcurarPorNumero(int numero)
    {
        return BuscarNaCollection(numero);
    }

    public List<Conta> ListarTodas()
    {
        return contas;
    }

    public bool Cadastrar(Conta conta)
    {
        if (conta == null) return false;

        if (BuscarNaCollection(conta.Numero) != null) 
            return false;

        conta.Numero = GerarNumero();
        contas.Add(conta);
        return true;
    }

    public bool Atualizar(Conta conta)
    {
        Conta? existente = BuscarNaCollection(conta.Numero);

        if (existente == null)
            return false;

        existente.Titular = conta.Titular;
        existente.Agencia = conta.Agencia;
        
        if (existente is ContaCorrente ccExistente &&
            conta is ContaCorrente ccNova)
        {
            ccExistente.Limite = ccNova.Limite;
        }
        else if (existente is ContaPoupanca cpExistente &&
                conta is ContaPoupanca cpNova)
        {
            cpExistente.Aniversario = cpNova.Aniversario;
        }

        return true;
    }

    public bool Deletar(int numero)
    {
        Conta? conta = BuscarNaCollection(numero);

        if (conta == null)
            return false;

        contas.Remove(conta);

        return true;
    }

    public bool Sacar(int numero, decimal valor)
    {
        Conta? c = BuscarNaCollection(numero);
        if (c == null) return false;

        return c.Sacar(valor);
    }

    public bool Depositar(int numero, decimal valor)
    {
        Conta? c = BuscarNaCollection(numero);
        if (c == null) return false;

        c.Depositar(valor);
        return true;
    }

    public bool Transferir(int numOrigem, int numDestino, decimal valor)
    {
        Conta? cOrigem = BuscarNaCollection(numOrigem);
        Conta? cDestino = BuscarNaCollection(numDestino);
        
        if (cOrigem == null || cDestino == null) return false;

        if (!cOrigem.Sacar(valor)) return false;
        
        cDestino.Depositar(valor);
        return true;
    }

    private int GerarNumero()
    {
        return proxNum++; //retorna primeiro, incrementa dps
    }

    private Conta? BuscarNaCollection(int numero)
    {
        return contas.Find(c => c.Numero == numero);
    }
}
