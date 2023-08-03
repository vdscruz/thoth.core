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

    public void MoverArquivoParaSucesso()
    {
        var nomeArquivo = Path.GetFileName(_caminho);
        var caminhoSucesso = Path.Combine(Path.GetDirectoryName(_caminho)!, "sucesso", nomeArquivo);
        File.Move(_caminho, caminhoSucesso);
    }
}