using Loop.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop.Domain.Entities
{
    public interface IEstagiarioRepository
    {
        void BaterEntrada(Frequencia frequencia);
        void BaterSaida(Frequencia frequencia);
    }
}
