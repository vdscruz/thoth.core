using Thoth.Core.Entidades;

namespace Thoth.Core.Eventos
{
    public class ArquivoProcessadoEvent : EventoBase
    {
        public DateTime DataHora { get; set; }
        public string Origem { get; set; }
        public IEnumerable<ItemExtrato> ItensExtrato { get; set; }

        public ArquivoProcessadoEvent(string origem, IEnumerable<ItemExtrato> items) : base(nameof(ArquivoProcessadoEvent))
        {
            DataHora = DateTime.Now;
            Origem = origem;
            ItensExtrato = items;
        }
    }
}
