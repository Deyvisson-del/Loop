using Loop.Domain.Entities;

namespace Loop.Application.DTOs
{
    /// <summary>
    /// Representa os dados de um estagiário utilizados para
    /// transferência entre camadas da aplicação (como Application e API).
    /// </summary>
    /// <remarks>
    /// Este DTO é usado para expor informações do estagiário
    /// de forma simplificada, sem incluir regras de negócio ou
    /// detalhes sensíveis, como a senha.
    /// </remarks>
    public class EstagiarioDTO
    {
        /// <summary>
        /// Identificador único do estagiário.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome completo do estagiário.
        /// </summary>
        public string Nome { get; set; } 

        /// <summary>
        /// Endereço de e-mail do estagiário.
        /// </summary>
        public string Email { get; set; } 

        public string Senha { get; set; }


        public EstagiarioDTO(string nome, string email, string senha)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }
    }
    }

