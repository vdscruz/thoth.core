using Thoth.Core.Entidades;

namespace Thoth.Core.Arquivos;

public abstract class Arquivo
{
    private string _caminho;
    private string _tipoArquivo;

    protected string Caminho => _caminho;

    public Arquivo(string caminhoDoArquivo, string tipo)
    {
        _caminho = caminhoDoArquivo;
        _tipoArquivo = tipo;
    }

    public abstract IEnumerable<ItemExtrato> ObterItensExtrato();
}