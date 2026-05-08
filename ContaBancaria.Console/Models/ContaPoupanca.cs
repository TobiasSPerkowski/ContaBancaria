namespace ContaBancaria.Console.Models;

public class ContaPoupanca : Conta
{
    public int Aniversario { get; set; }

    public ContaPoupanca(
        int agencia, 
        int aniversario,
        string titular, 
        decimal saldo = 0.0m,
        int numero = 0
        )
    {
        Agencia = agencia;
        Titular = titular;
        Aniversario = aniversario;
        Saldo = saldo;
        Numero = numero;
    }

    // formatar para visualizacao
    public override string ToString()
    {
        return base.ToString() + $"\nTipo: Conta Poupança\nAniversario: {Aniversario}";
    }

    // formatar para salvamento
    public override string ParaArquivo()
    {
        return $"P;{Numero};{Agencia};{Titular};{Saldo};{Aniversario}";
    }
}
