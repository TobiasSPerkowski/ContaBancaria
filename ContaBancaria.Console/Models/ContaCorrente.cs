namespace ContaBancaria.Console.Models;

public class ContaCorrente : Conta
{
    public decimal Limite {get; set; }

    public override bool Sacar(decimal valor)
    {
        if (valor <= 0 || Saldo + Limite < valor) 
            return false;
            
        Saldo -= valor;
        return true;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nTipo: Conta Corrente\nLimite: {Limite:C}";
    }
}
