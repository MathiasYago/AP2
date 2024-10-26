class Progam
{
    static void Main(string[] args)
    {
        Agencia agencia = new Agencia();

        Destino destino1 = new Destino("Rio de Janeiro", "Brasil", "RJ001", "Praias do Rio");
        Destino destino2 = new Destino("Cancun", "México", "MX001", "Resorts de Cancun");

        agencia.CadastrarDestino(destino1);
        agencia.CadastrarDestino(destino2);

        Cliente cliente1 = new Cliente("Nicolas Santos", 1, "Nicolas@gmail.com", "9999-9999");
        Cliente cliente2 = new Cliente("Pedro Augusto", 2, "PedroAugusto@gmail.com", "8888-8888");

        agencia.CadastrarCliente(cliente1);
        agencia.CadastrarCliente(cliente2);
        
        PacoteTuristico pacote1 = new PacoteTuristico(1, "Pacote Rio de Janeiro", destino1, new DateTime(2024, 10, 10), new DateTime(2024, 10, 11), 5000m, 5);
        PacoteTuristico pacote2 = new PacoteTuristico(2, "Pacote Cancun", destino2, new DateTime(2024, 09, 10), new DateTime(2024, 10, 11), 5000m, 5);

        agencia.CadastraPacoteTuristico(pacote1);
        agencia.CadastraPacoteTuristico(pacote2);

        Console.WriteLine("\nDestinos cadastrados");
        agencia.ListarDestinos();

        Console.WriteLine("\nClientes cadastrados()");
        agencia.ListarClientes();

        Console.WriteLine("\nPacotes turisticos cadastrados:()");
        agencia.ListarPacotes();

        Console.WriteLine("\nRealizando reservas");
        agencia.FazerReserva(1, 1, 1);
        agencia.FazerReserva(2, 2, 2);

        Console.WriteLine("\nTentativa de reserva duplicada");
        agencia.FazerReserva(3, 2, 1);

        Console.WriteLine("\nReservas de Nicolas");
        agencia.ConsultarReservasPorCliente(1);

        Console.WriteLine("\nCancelando reserva de Nicolas");
        agencia.CancelarReserva(1);

        Console.WriteLine("\nReserva de Nicolas após o cancelamento:");
        agencia.ConsultarReservasPorCliente(1);
    }
}