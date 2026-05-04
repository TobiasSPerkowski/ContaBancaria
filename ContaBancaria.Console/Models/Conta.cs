namespace ContaBancaria.Console.Models;

public class Conta
{
    public int Numero { get; set; }
    public int Agencia { get; set; }
    public string? Titular { get; set; }
    public decimal Saldo {get; protected set; }

    public virtual bool Sacar(decimal valor)
    {
        if (valor <= 0 || Saldo < valor) 
            return false;
        Saldo -= valor;
        return true;
    }

    public virtual void Depositar(decimal valor)
    {
        if (valor > 0) 
            Saldo += valor; 
    }

    // visualizar
    public override string ToString()
    {
        return $"Conta: {Numero}\nTitular: {Titular}\nSaldo: {Saldo:C}";
    }
}
