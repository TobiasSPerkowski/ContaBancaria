namespace ContaBancaria.Console.Models;

public class ContaPoupanca : Conta
{
    public int Aniversario { get; set; }

    public override string ToString()
    {
        return base.ToString() + $"\nTipo: Conta Poupança\nAniversario: {Aniversario}";
    }
}
