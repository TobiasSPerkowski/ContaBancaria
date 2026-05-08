namespace ContaBancaria.Console.Models;

public abstract class Conta
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

    public virtual bool Depositar(decimal valor)
    {
        if (valor <= 0)   
            return false; 
        
        Saldo += valor;
        return true;
    }

    // formatar para visualizacao
    public override string ToString()
    {
        return $"Conta: {Numero}\nAgencia: {Agencia}\n"
                + $"Titular: {Titular}\nSaldo: {Saldo:C}";
    }

    // formatar para salvamento
    public abstract string ParaArquivo();
}
