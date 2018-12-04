using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoApi.Models;

namespace AvaliacaoApi.Business.Interfaces
{
    public interface IJogoBusiness : IBaseBusiness<Jogo>
    {
        bool ValidarJogo(Jogo jogo);
        List<string> BuscarNumerosOpcoesPorTipoSorteio(int tipoSorteio);
    }
}
