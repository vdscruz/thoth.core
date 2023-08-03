using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoth.Core.Eventos;
using Thoth.Core.Infra.Mensageria.Interfaces;

namespace Thoth.Core.Infra.Mensageria.Implementacao.Producer
{
    internal class AmazonSQSEventProducer : IProducer
    {
        public Task ProduceAsync<T>(string topic, T evento) where T : EventoBase
        {
            throw new NotImplementedException();
        }
    }
}