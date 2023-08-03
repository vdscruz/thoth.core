using System.Text.Json.Serialization;
using Thoth.Core.Eventos;

namespace Thoth.Core.Infra.Mensageria.Interfaces;

public interface IConsumer
{
    IEnumerable<(EventoBase, Action)> Consume(string topic, JsonConverter converter, CancellationToken cancellationToken);
}