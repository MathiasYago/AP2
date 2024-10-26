public interface IPesquisavel<T>
{
    T PesquisarPorCodigo (string codigo);
    
    IEnumerable<T> PesquisarPorNome (string nome);
}