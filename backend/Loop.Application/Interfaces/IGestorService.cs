using Loop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop.Application.Interfaces
{
    public interface IGestorService
    {
        Task<EstagiarioDTO?> ObterPorEmailAsync(string email);
    }
}
