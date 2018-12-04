using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoApi.Models;

namespace AvaliacaoApi.Business.Interfaces
{
    public interface ISistemaBusiness
    {
        List<Premiado> GetPremiados();
        Sorteio GetSorteio();
        List<Jogo> GetTodos();
        Jogo AddJogo(Jogo jogo);

    }
}
