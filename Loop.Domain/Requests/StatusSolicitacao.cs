using System.ComponentModel;

namespace Loop.Domain.Requests
{
    public enum StatusSolicitacao
    {
        [Description("Aprovado")] AP,
        [Description("Reprovado")] RP,
        [Description("Pendente")] PE,
    }
}