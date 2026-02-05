using Loop.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop.Domain.Interfaces
{
    public interface IEstagiarioRepository
    {
        void BaterEntrada(Frequencia frequencia);
        void BaterSaida(Frequencia frequencia);
        void SolicitarAjuste(Solicitacao solicitacao);
    }
}
