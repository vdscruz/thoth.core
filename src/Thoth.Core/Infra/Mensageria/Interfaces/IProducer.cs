using Thoth.Core.Eventos;

namespace Thoth.Core.Infra.Mensageria.Interfaces
{
    public interface IProducer
    {
        Task ProduceAsync<T>(string topic, T evento) where T : EventoBase;
    }
}