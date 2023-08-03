using ClosedXML.Excel;
using System.IO;
using Thoth.Core.Entidade.Enum;
using Thoth.Core.Entidades;

namespace Thoth.Core.Arquivos;

public class ExtratoB3 : Arquivo
{
    public ExtratoB3(string caminhoDoArquivo) : base(caminhoDoArquivo, nameof(ExtratoB3))
    {
    }

    public override IEnumerable<ItemExtrato> ObterItensExtrato()
    {
        using var workbook = new XLWorkbook(Caminho);
        var worksheet = workbook.Worksheet(1);
        var rows = worksheet.RowsUsed().Skip(1);

        foreach (var row in rows)
        {
            var operacao = Enum.Parse<Operacao>(row.Cell(1).GetString());
            var data = row.Cell(2).GetDateTime();
            var tipoMovimento = ConverterParaTipoMovimento(row.Cell(3).GetString());
            var (codigo, nomeProduto) = ObterCodigoENomeDoProduto(row.Cell(4).GetString());
            var instituicao = row.Cell(5).GetString();
            var quantidade = row.Cell(6).GetDouble();
            var temPrecoUnitario = double.TryParse(row.Cell(7).GetValue<string>(), out var precoUnitario);
            var valorOperacao = row.Cell(8).GetDouble();

            if (!temPrecoUnitario && quantidade > 0)
            {
                precoUnitario = valorOperacao / quantidade;
            }

            yield return new ItemExtrato
            {
                Data = data,
                Operacao = operacao,
                Codigo = codigo,
                TipoMovimento = tipoMovimento,
                NomeProduto = nomeProduto,
                Instituicao = instituicao,
                Quantidade = quantidade,
                PrecoUnitario = precoUnitario,
                Moeda = Moeda.BRL,
                ValorDaMoedaNoDia = 1,
                ValorOperacao = valorOperacao
            };
        }

        MoverArquivoParaSucesso();
    }

    private (string codigo, string nomeProduto) ObterCodigoENomeDoProduto(string nomeProduto)
    {
        if (nomeProduto.Contains("Tesouro"))
        {
            return (nomeProduto.Trim(), nomeProduto.Trim());
        }

        var lista = nomeProduto.Split(" - ");
        return (lista[0], lista[1]);
    }

    private TipoMovimento ConverterParaTipoMovimento(string tipoMovimento)
    {
        return tipoMovimento switch
        {
            "Compra" => TipoMovimento.Compra,
            "Venda" => TipoMovimento.Venda,
            "Transfer�ncia - Liquidação" => TipoMovimento.TransferenciaLiquidacao,
            "Rendimento" => TipoMovimento.Rendimento,
            "Rendimentos" => TipoMovimento.Rendimento,
            "Juros Sobre Capital Próprio" => TipoMovimento.JurosSobreCapitalProprio,
            "Juros" => TipoMovimento.Juros,
            "Dividendos" => TipoMovimento.Dividendo,
            "Dividendo" => TipoMovimento.Dividendo,
            "Cobran�a de Taxa Semestral" => TipoMovimento.CobrancaTaxaSemestral,
            "Restituição de Capital" => TipoMovimento.RestituicaoCapital,
            "Leil�o de Fração" => TipoMovimento.LeilaoFracao,
            "Direitos de Subscrição - N�o Exercido" => TipoMovimento.DireitoSubscricaoNaoExercido,
            "Direito de Subscrição" => TipoMovimento.DireitoSubscricao,
            "Atualização" => TipoMovimento.Atualizacao,
            "Grupamento" => TipoMovimento.Grupamento,
            "Bonificação em Ativos" => TipoMovimento.BonificacaoEmAtivos,
            "Desdobro" => TipoMovimento.Desdobro,
            "Cessão de Direitos - Solicitada" => TipoMovimento.CessaoDireitosSolicitada,
            "Cessão de Direitos" => TipoMovimento.CessaoDireitos,
            "Fração em Ativos" => TipoMovimento.FracaoAtivos,
            "Incorporação" => TipoMovimento.Incorporacao,
            "Transfer�ncia" => TipoMovimento.Transferencia,
            "Cisao" => TipoMovimento.Cisao,
            "TRANSFERENCIA SEM FINANCEIRO" => TipoMovimento.TransferenciaSemFinanceiro,
            _ => TipoMovimento.Desconhecido
        };
    }
}