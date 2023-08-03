using Thoth.Core.Entidade.Enum;

namespace Thoth.Core.Entidades;

public struct ItemExtrato
{
    public DateTime Data { get; set; }
    
    public Operacao Operacao { get; set; }
    
    public string Codigo { get; set; }
    
    public TipoMovimento TipoMovimento { get; set; }
    
    public string NomeProduto { get; set; }
    
    public string Instituicao { get; set; }
    
    public double Quantidade { get; set; }
    
    public double PrecoUnitario { get; set; }
    
    public Moeda Moeda { get; set; }
    
    public double ValorDaMoedaNoDia { get; set; }
    
    public double ValorOperacao { get; set; }
}