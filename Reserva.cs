public class Reserva : IReservavel
{
    public int Codigo { get; set; }
    public PacoteTuristico Pacote { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime DataReserva { get; set; }

    public Reserva(int codigo, PacoteTuristico pacote, Cliente cliente)
    {
        Codigo = codigo;
        Pacote = pacote;
        Cliente = cliente;
        DataReserva = DateTime.Now; // Define a data da reserva como agora
    }

    public void Reservar()
    {
        // Verifica se o pacote possui vagas disponíveis
        if (Pacote.VagasDisponiveis > 0)
        {
            Pacote.VagasDisponiveis--; // diminui vagas
            Console.WriteLine($"Reserva realizada com sucesso para {Cliente.Nome} no pacote {Pacote.Descricao}.");
        }
        else
        {
            Console.WriteLine("Não há vagas disponíveis para este pacote.");
        }
    }

    public void Cancelar()
    {
        if (Pacote.ClientesReservados.Contains(Cliente))
        {
            Pacote.ClientesReservados.Remove(Cliente); // Remover cliente lista
            Pacote.VagasDisponiveis++; // Aumenta o número de vagas disponíveis
            Console.WriteLine($"Reserva cancelada com sucesso para {Cliente.Nome} no pacote {Pacote.Descricao}.");
        }
        else
        {
            Console.WriteLine("Reserva não encontrada para este cliente.");
        }
    }

    public override string ToString()
    {
        return $"Reserva Código: {Codigo}, Cliente: {Cliente.Nome}, Pacote: {Pacote.Descricao}, Data: {DataReserva}";
    }
}