public class Destino
{
  
    private string nomeLocal;
    private string pais;
    private string codigo;
    private string descricao;

   
    public string NomeLocal
    {
        get { return nomeLocal; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome do local não pode ser vazio.");
            }
            nomeLocal = value;
        }
    }

    public string Pais
    {
        get { return pais; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O país não pode ser vazio.");
            }
            pais = value;
        }
    }

    public string Codigo
    {
        get { return codigo; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O código não pode ser vazio.");
            }
            codigo = value;
        }
    }


    public string Descricao
    {
        get { return descricao; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A descrição não pode ser vazia.");
            }
            descricao = value;
        }
    }

   
    public Destino(string nomeLocal, string pais, string codigo, string descricao)
    {
        NomeLocal = nomeLocal;
        Pais = pais;
        Codigo = codigo;
        Descricao = descricao;
    }

    
    public void ExibirInformacoes()
    {
        Console.WriteLine("Informações do Destino");
        Console.WriteLine($"Nome do Local: {NomeLocal}");
        Console.WriteLine($"País: {Pais}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Descrição: {Descricao}");
        
    }

    public override string ToString()
    {
        return $"Destino: {NomeLocal}, Pais: {Pais}, codigo: {codigo}, Descrição: {Descricao}";
    }
}