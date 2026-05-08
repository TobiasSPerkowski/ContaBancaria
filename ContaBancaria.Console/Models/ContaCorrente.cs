namespace ContaBancaria.Console.Models;

public class ContaCorrente : Conta
{
    public decimal Limite {get; set; }

    public ContaCorrente( 
        int agencia, 
        string titular, 
        decimal limite,
        decimal saldo = 0.0m,
        int numero = 0
        )
    {
        Agencia = agencia;
        Titular = titular;
        Limite = limite;
        Saldo = saldo;
        Numero = numero;
    }

    public override bool Sacar(decimal valor)
    {
        if (valor <= 0 || Saldo + Limite < valor) 
            return false;
            
        Saldo -= valor;
        return true;
    }

    // formatar para visualizacao
    public override string ToString()
    {
        return base.ToString() + $"\nTipo: Conta Corrente\nLimite: {Limite:C}";
    }

    // formatar para salvamento
    public override string ParaArquivo()
    {
        return $"C;{Numero};{Agencia};{Titular};{Saldo};{Limite}";
    }
}
