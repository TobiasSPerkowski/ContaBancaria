using ContaBancaria.Console.Models;

namespace ContaBancaria.Console.Repositories;

public interface IContaRepository
{
    public Conta? ProcurarPorNumero(int numero);
    public List<Conta> ListarTodas();
    public bool Cadastrar(Conta conta);
    public bool Atualizar(Conta conta);
    public bool Deletar(int numero);
    public bool Sacar(int numero, decimal valor);
    public bool Depositar(int numero, decimal valor);
    public bool Transferir(int numOrigem, int numDestino, decimal valor);
}
