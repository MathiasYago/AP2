public class PacoteTuristico : ServicoViagem, IReservavel, IPesquisavel<PacoteTuristico>
{
    public Destino Destino { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    private decimal preco;
    private int vagasDisponiveis;

    public List<Cliente> ClientesReservados { get; set; }

    public int VagasDisponiveis
    {
        get { return vagasDisponiveis; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O número de vagas não pode ser negativo.");
            }
            vagasDisponiveis = value;
        }
    }

    public decimal Preco
    {
        get { return preco; }
        set
        {
            if (value < 0)
                throw new ArgumentException("O preço não pode ser negativo.");
            preco = value;
        }
    }

    public PacoteTuristico(int codigo, string nome, Destino destino, DateTime dataInicio, DateTime dataFim, decimal preco, int vagasDisponiveis)
        : base(codigo, nome)
    {
        this.Destino = destino;
        this.DataInicio = dataInicio;
        this.DataFim = dataFim;
        this.Preco = preco;
        this.VagasDisponiveis = vagasDisponiveis;
        ClientesReservados = new List<Cliente>();
        Console.WriteLine("Pacote turístico criado com sucesso.");
    }


    public PacoteTuristico PesquisarPorCodigo(string codigo)
    {
        if (int.TryParse(codigo, out int codigoInt))
        {
            if (this.Codigo == codigoInt)
            {
                return this;
            }
        }
        return null; 
    }

    public IEnumerable<PacoteTuristico> PesquisarPorNome(string nome)
    {
        if (string.Equals(this.Descricao, nome, StringComparison.OrdinalIgnoreCase))
        {
            return new List<PacoteTuristico> { this };
        }
        return Enumerable.Empty<PacoteTuristico>();
    }

    // Implementação classe base
    public override void Reservar(Cliente cliente)
    {
        if (VagasDisponiveis > 0)
        {
            VagasDisponiveis--;
            ClientesReservados.Add(cliente);
            Console.WriteLine($"Reserva realizada com sucesso para o cliente {cliente.Nome}. Vagas restantes: {VagasDisponiveis}");
        }
        else
        {
            Console.WriteLine("Não há vagas disponíveis.");
        }
    }

    // Método sobrecarregado
    public void Reservar()
    {
        // Método para reservar uma vaga sem especificar o cliente
        if (VagasDisponiveis > 0)
        {
            VagasDisponiveis--;
            Console.WriteLine("Reserva realizada com sucesso (vaga sem cliente). Vagas restantes: " + VagasDisponiveis);
        }
        else
        {
            Console.WriteLine("Não há vagas disponíveis.");
        }
    }

    public override void Cancelar(Cliente cliente)
    {
        if (ClientesReservados.Contains(cliente))
        {
            ClientesReservados.Remove(cliente);
            VagasDisponiveis++;
            Console.WriteLine($"Reserva cancelada para o cliente {cliente.Nome}. Vagas disponíveis: {VagasDisponiveis}");
        }
        else
        {
            Console.WriteLine("Reserva não encontrada para o cliente informado.");
        }
    }

    // Método sobrecarregado
    public void Cancelar()
    {
        if (ClientesReservados.Count > 0)
        {
            var cliente = ClientesReservados.Last();
            ClientesReservados.Remove(cliente);
            VagasDisponiveis++;
            Console.WriteLine($"Reserva cancelada para o último cliente {cliente.Nome}. Vagas disponíveis: {VagasDisponiveis}");
        }
        else
        {
            Console.WriteLine("Nenhuma reserva encontrada para cancelar.");
        }
    }
    public override string ToString()
    {
        return $"Pacote: {Descricao}, Destino: {Destino.NomeLocal}, Data: {DataInicio.ToShortDateString()} - {DataFim.ToShortDateString()}, Preço: {Preco:c}, Vagas Disponiveis: {VagasDisponiveis}";
    }
}