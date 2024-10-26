public class Agencia
{
 
 private List<Destino> destinos;
 private List<Cliente> clientes;
 private List<PacoteTuristico> pacotes;
 private List<Reserva> reservas;
 
 
public Agencia()
  {
    destinos = new List<Destino>();
    clientes = new List<Cliente>();
    pacotes = new List<PacoteTuristico>();
    reservas = new List<Reserva>();
  }

public void CadastrarDestino(Destino destino)
{
  if (destino == null)
  {
    Console.WriteLine("Destino invalido.");
    return;
  }
  if (destinos.Contains(destino))
  {
    Console.WriteLine("Este destino já está cadastrado.");
    return;
  }
  destinos.Add(destino);
  Console.WriteLine("Destino caadastrado com sucesso");
}  
public Destino ConsultarDestinoPorCodigo(string codigo)
{
  string codigoString= codigo.ToString();
  foreach (var destino in destinos)
  {
    if (destino.Codigo == codigo)
    {
      return destino;
    }
  } 
  Console.WriteLine("Destino não encontrado");
  return null; 
}
public void ListarDestinos()
{
  foreach (var destino in destinos)
  {
    Console.WriteLine(destino.ToString());
  }
}
public void CadastrarCliente(Cliente cliente)
{
  if (cliente == null)
  {
    Console.WriteLine("Cliente não encontrado");
    return;
  }
  if (clientes.Contains(cliente))
  {
    Console.WriteLine("Este cliente ja esta cadastrado");
    return;
  }
  clientes.Add(cliente);
  Console.WriteLine("Cliente cadastrado com sucesso.");
  }
  public Cliente ConsultarClientePorCodigo(int codigo)
  {
    foreach (var cliente in clientes)
    {
      if (cliente.Codigo == codigo)
      {
        return cliente;
      }
    }
    Console.WriteLine("Cliente não encontrado.");
    return null;
  }
public void ListarClientes()
 {
  foreach (var cliente in clientes)
  {
    Console.WriteLine(cliente.ToString());
  }
 }  
public void CadastraPacoteTuristico(PacoteTuristico pacote)
{
  if (pacote == null)
  {
    Console.WriteLine("cliente não encontrado");
    return;
  }
  if (pacotes.Contains(pacote))
  {
   Console.WriteLine("Este pacote ja está cadastrado");
   return;
  }
  pacotes.Add(pacote);
  Console.WriteLine("Pacote turistico cadastrado com sucesso");
  }
public PacoteTuristico ConsultarPacotePorCodigo(int Codigo)
{
  foreach (var pacote in pacotes)
  {
    if (pacote.Codigo == Codigo)
    {
      return pacote;
    }
  }
  Console.WriteLine("Pacote não encontrado");
  return null;
 }  
public void ListarPacotes()
{
  foreach(var pacote in pacotes)
  {
    Console.WriteLine(pacote.ToString());
  }
} 
public void FazerReserva(int codigoReserva, int codigoCliente, int codigoPacote)
{
  Cliente cliente = ConsultarClientePorCodigo(codigoCliente);
  PacoteTuristico pacote = ConsultarPacotePorCodigo(codigoPacote);

  if(cliente == null)
  {
    Console.WriteLine("Clietne não encontrado.");
    return;
  }
  if (pacote == null)
  {
    Console.WriteLine("Pacote turistico não encontrado");
    return;
  }
  if (pacote.VagasDisponiveis <= 0)
  {
  Console.WriteLine("Não ha vagas disponiveis para este pacote");
  return;
  }
  foreach (var reserva in reservas)
  {
    if (reserva.Cliente == cliente && reserva.Pacote == pacote)
    {
      Console.WriteLine("O cliente ja fez uma reserva para este pacote.");
      return;
    }
  }
  Reserva novaReserva = new Reserva(codigoReserva, pacote, cliente);
  reservas.Add(novaReserva);
  pacote.VagasDisponiveis--;
  Console.WriteLine("Reserva realizada com sucesso.");
}
public void CancelarReserva(int codigoReserva)
{
  Reserva reserva = null;
  foreach (var r in reservas)
  {
    if (r.Codigo == codigoReserva)
    {
      reserva = r;
      break;
    }
  }
  {
    if (reserva == null)
    {
      Console.WriteLine("Reserva não encontrado");
      return;
    }
    reservas.Remove(reserva);
    reserva.Pacote.VagasDisponiveis++;
    Console.WriteLine("Reserva cancelada com sucesso");
  }
}
public void ConsultarReservasPorCliente(int codigoCliente)
{
  Cliente cliente = ConsultarClientePorCodigo(codigoCliente);
  if (cliente == null)
  {
    Console.WriteLine("Cliente não encontrado");
    return;
  }
  var reservasCliente = reservas.Where(r => r.Cliente == cliente).ToList();
  if (reservasCliente.Count == 0)
  {
    Console.WriteLine("Nenhuma reserva encontrada para este cliente.");
    return;
  }
  foreach (var reserva in reservasCliente)
  {
    Console.WriteLine(reserva.ToString());
  }
}
}