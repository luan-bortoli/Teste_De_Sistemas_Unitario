namespace Banco;

public class ContaBancaria
{
    public string Titular { get; private set; }
    public decimal Saldo { get; private set; }

    public ContaBancaria(string titular, decimal saldoInicial = 0)
    {
        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("O titular é obrigatório.", nameof(titular));

        if (saldoInicial < 0)
            throw new ArgumentException("O saldo inicial não pode ser negativo.", nameof(saldoInicial));

        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do depósito deve ser positivo.", nameof(valor));

        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do saque deve ser positivo.", nameof(valor));

        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        Saldo -= valor;
    }

    public bool TemSaldoSuficiente(decimal valor)
    {
        return valor <= Saldo;
    }
}