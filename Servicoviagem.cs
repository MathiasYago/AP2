public abstract class ServicoViagem

{
 public int Codigo {get; set;}

 public string Descricao {get; set;}
 
    public ServicoViagem( int codigo, string descricao)
    {
     Codigo = codigo;
     Descricao = descricao;
    }
    public abstract void Reservar(Cliente cliente);
    public abstract void Cancelar(Cliente cliente);
 
}