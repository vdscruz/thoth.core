using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Thoth.Core.Eventos;
using Thoth.Core.Infra.Mensageria.Interfaces;

namespace Thoth.Core.Infra.Mensageria.Implementacao.Consumer
{
    public class KafkaEventConsumer : IConsumer
    {
        public IEnumerable<(EventoBase, Action)> Consume(string topic, JsonConverter converter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}