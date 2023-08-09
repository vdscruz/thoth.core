using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Thoth.Core.Eventos;
using Thoth.Core.Infra.Mensageria.Interfaces;

namespace Thoth.Core.Infra.Mensageria.Implementacao.Producer
{
    internal class KafkaEventProducer : IProducer
    {
        private readonly ProducerConfig _config;
        public KafkaEventProducer(ProducerConfig config)
        {
            _config = config;
        }
        public async Task ProduceAsync<T>(string topic, T evento) where T : EventoBase
        {
            using var producer = new ProducerBuilder<string, string>(_config)
            .SetKeySerializer(Serializers.Utf8)
            .SetValueSerializer(Serializers.Utf8)
            .Build();

            var eventMessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize(evento, evento.GetType())
            };

            var deliveryResult = await producer.ProduceAsync(topic, eventMessage);

            if (deliveryResult.Status == PersistenceStatus.NotPersisted)
            {
                throw new Exception($"Could not produce {evento.GetType().Name} message to topic - {topic} due to the following reason: {deliveryResult.Message}.");
            }
        }
    }
}