namespace Thoth.Core.Entidade.Enum;

public enum TipoMovimento
{
    TransferenciaLiquidacao = 0,
    Compra = 1,
    Venda = 2,
    Rendimento = 3, // Rendimento
    JurosSobreCapitalProprio = 4, // Juros Sobre Capital Próprio
    Juros = 5, // Juros
    Dividendo = 6, // Dividendo
    CobrançaTaxaSemestral = 7,
    RestituicaoCapital = 8,
    LeilaoFracao = 9, // Leilão de Fração
    DireitoSubscricao = 10, // Direito de Subscrição
    Atualizacao = 11, // Atualização
    Grupamento = 12, // Grupamento
    BonificacaoEmAtivos = 12, // Bonificação em Ativos
    DireitoSubscricaoNaoExercido = 13, // Direitos de Subscrição - Não Exercido
    Desdobro = 14, // Desdobro
    CessaoDireitosSolicitada = 15, // Cessão de Direitos - Solicitada
    CessaoDireitos = 16, // Cessão de Direitos
    CobrancaTaxaSemestral = 17, // Cobrança de Taxa Semestral
    FracaoAtivos = 18, // Fração em Ativos
    Incorporacao = 19, // Incorporação
    Transferencia = 20, // Transferência
    Cisao = 21, // Cisão
    TransferenciaSemFinanceiro = 22, // TRANSFERENCIA SEM FINANCEIRO
    Desconhecido = 999,
}