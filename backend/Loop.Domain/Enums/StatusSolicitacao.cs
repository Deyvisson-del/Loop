using System.ComponentModel;
namespace Loop.Domain.Enums
{
    public enum StatusSolicitacao
    {
        [Description("Aprovado")] AP,
        [Description("Reprovado")] RP,
        [Description("Pendente")] PE,
    }
}
