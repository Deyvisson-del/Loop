using Loop.Domain.Requests;

namespace Loop.Domain.Interfaces
{
    public interface IFrequenciaRepository
    {
        Frequencia? ObterPorEstagiarioEData(int estagiarioId, DateTime data);
        void Adicionar(Frequencia frequencia);
        void Atualizar(Frequencia frequencia);
    }
}