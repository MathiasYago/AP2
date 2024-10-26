public class Cliente
{
    public string Nome { get; set; }
    public int Codigo { get; set; }
    public string NumeroIdentificacao { get; set; }
    public string Contato { get; set; }

    public Cliente(string nome, int codigo, string documento, string contato)
    {
        Nome = nome;
        Codigo = codigo;
        NumeroIdentificacao = documento;
        Contato = contato;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine("Informações do cliente:");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Número de Identificação: {NumeroIdentificacao}");
        Console.WriteLine($"Contato: {Contato}");
    }

    public override bool Equals(object obj)
    {
        if (obj is Cliente cliente)
        {
            return this.Codigo == cliente.Codigo; // Comparar por código
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Codigo.GetHashCode(); // Usar o código para hash
    }

    public override string ToString()
    {
        return $"{Nome} (Código: {Codigo}, ID: {NumeroIdentificacao}, Contato: {Contato})";
    }
}