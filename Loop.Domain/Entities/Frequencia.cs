using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop.Domain.Entities
{
    public class Frequencia
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid EstagiarioId { get; set; }
        public DateTime DataChegada { get; set; }
        public DateTime DataSaida { get; set; }
        public TimeOnly HoraChegada { get; set; }
        public TimeOnly HoraSaida { get; set; }
        public bool Presente { get; set; }

        public Frequencia(Guid estagiarioId, DateTime datachegada, DateTime datasaida, TimeOnly horachegada, TimeOnly horasaida, bool presente)
        {
                EstagiarioId = estagiarioId;
                DataChegada = datachegada;
                DataSaida = datasaida;
                HoraChegada = horachegada;
                HoraSaida = horasaida;
                Presente = presente;
        }
    }
}
